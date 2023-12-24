using AutoMapper;
using Newtonsoft.Json;
using System.Collections.Generic;
using TestTask.DataModel;
using TestTask.DataModel.ResponseDTO;
using TestTask.IService;
using TestTask.Model;
using TestTask.Repository;

namespace TestTask.Service
{
    public class SupplierService: ISupplierService
    {
        private readonly IRepository<Supplier> _repository;
        private readonly IMapper _mapper;
        private readonly IHotelService _hotelService;


        public SupplierService(IRepository<Supplier> repository, IMapper mapper, IHotelService hotelService)
        {
            _repository = repository;
            _mapper = mapper;
            _hotelService = hotelService;
        }

        public TTResponseModel<List<SupplierDTO>> GetHotelFromSuplier()
        {
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Suplier.json");
                string jsonData = string.Empty;
                if (File.Exists(filePath))
                {
                    jsonData = File.ReadAllText(filePath);
                }
                else
                {
                    return new TTResponseModel<List<SupplierDTO>>() { IsSuccess = false, Data = null, Message = "File not found" };
                }

                var result = JsonConvert.DeserializeObject<List<SupplierDTO>>(jsonData);
                return new TTResponseModel<List<SupplierDTO>>() { IsSuccess = true, Data = result, Message = "Success" };
            }
            catch (Exception ex)
            {
                return new TTResponseModel<List<SupplierDTO>>() { IsSuccess = false, Data = null, Message = ex.Message };
            }
        }

        public bool SaveSuppliers(List<SupplierDTO> supplierDTOs)
        {
            if (supplierDTOs.Any())
            {
                supplierDTOs.ForEach(supplierDTO => { 
                    CreateSupplier(supplierDTO);
                });
            }
            return true;
        }

        public bool CreateSupplier(SupplierDTO suppliercDTO)
        {
            try
            {
                if (suppliercDTO == null)
                {
                    throw new ArgumentNullException();
                }
                var supplier = _repository.Find(x => x.SupplierName == suppliercDTO.SupplierName).FirstOrDefault();
                if (supplier != null)
                {
                    return false;
                }
                var supplierObject= _mapper.Map<Supplier>(suppliercDTO);
                supplierObject= _repository.Add(supplierObject);
                if (suppliercDTO.Hotels.Count > 0)
                {
                   var result= _hotelService.ConsolidateHotelData(supplierObject.SupplierId, suppliercDTO.Hotels);
                }
                return true;    
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        //public List<SupplierDTO> GetSuppliers()
        //{

        //}
    }
}
