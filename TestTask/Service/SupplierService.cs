using AutoMapper;
using TestTask.DataModel;
using TestTask.IService;
using TestTask.Model;
using TestTask.Repository;

namespace TestTask.Service
{
    public class SupplierService
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
                _repository.Add(supplierObject);
                if (suppliercDTO.Hotels.Count > 0)
                {

                }
                return true;    
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
