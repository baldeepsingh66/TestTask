using System;
using Newtonsoft.Json;
using System.IO;
using TestTask.IService;
using TestTask.DataModel.ResponseDTO;
using TestTask.DataModel;
using TestTask.Model;
using TestTask.Repository;
using TestTask.CommonHelper;

namespace TestTask.Service
{
    public class HotelService : IHotelService
    {
        private readonly IRepository<Hotel> _repository;
        private readonly IAddressServices _addressServices;
        public HotelService(IRepository<Hotel> repository, IAddressServices addressServices) 
        {
            _repository = repository;
            _addressServices = addressServices;
        }
        public async Task<TTResponseModel<List<SupplierDTO>>> GetHotelFromSuplier()
        {
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Suplier.json");
                string jsonData=string.Empty;
                if (File.Exists(filePath))
                {
                    jsonData = File.ReadAllText(filePath);
                }
                else
                {
                    return new TTResponseModel<List<SupplierDTO>>() { IsSuccess = false, Data = null, Message = "File not found" };
                }
                var result= JsonConvert.DeserializeObject<List<SupplierDTO>>(jsonData);
                return new TTResponseModel<List<SupplierDTO>>() { IsSuccess = true, Data = result, Message="Success" };
            }
            catch(Exception ex)
            {
                return new TTResponseModel<List<SupplierDTO>>() { IsSuccess = false, Data = null, Message = ex.Message };
            }
        }

        public List<HotelDTO> GetAllHotel()
        {
            var hotels= _repository.GetAll().ToList();
            if(hotels != null && hotels.Count > 0)
            {
                var hotelsDTO = new List<HotelDTO>();
                hotels.ForEach(hotel =>
                {
                    var hotelDTO = new HotelDTO();
                    hotelDTO.Id = hotel.Id;
                    hotelDTO.Name= hotel.Name;
                    hotelDTO.Address = _addressServices.Get(hotelDTO.Id);
                    hotelsDTO.Add(hotelDTO);
                });
                return hotelsDTO;
            }
            return null;
        }

        public bool ConsolidateHotelData(int supplierId, List<HotelDTO> NewHotels, List<HotelDTO> OldHotels)
        {
            NewHotels.ForEach(hotel =>
            {
                var oldHotel = OldHotels.Where(x => Helper.AreNamesSimilar(x.Name, hotel.Name) && hotel.Equals(x.Address)).FirstOrDefault();
                if (oldHotel== null)
                {

                }
            });
            return true;
        }

    }
}
