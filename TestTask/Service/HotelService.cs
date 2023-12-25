using System;
using Newtonsoft.Json;
using System.IO;
using TestTask.IService;
using TestTask.DataModel.ResponseDTO;
using TestTask.DataModel;
using TestTask.Model;
using TestTask.Repository;
using TestTask.CommonHelper;
using AutoMapper;

namespace TestTask.Service
{
    public class HotelService : IHotelService
    {
        private readonly IRepository<Hotel> _repository;
        private readonly IRepository<SupplierHotel> _shRepository;
        private readonly IRepository<Address> _hRepository;
        private readonly IAddressServices _addressServices;
        private readonly IMapper _mapper;
        public HotelService(IRepository<Hotel> repository, IAddressServices addressServices, IMapper mapper, IRepository<SupplierHotel> shRepository) 
        {
            _repository = repository;
            _addressServices = addressServices;
            _mapper = mapper;
            _shRepository = shRepository;
        }

        public List<HotelDTO> GetAllHotel()
        {
            var hotels= _repository.GetAll().ToList();
            var hotelsDTO = new List<HotelDTO>();

            if (hotels != null && hotels.Count > 0)
            {
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
            return hotelsDTO;
        }

        public bool ConsolidateHotelData(int supplierId, List<HotelDTO> NewHotels)
        {
            var oldHotels = GetAllHotel();
            if (oldHotels.Any())
            {
                NewHotels.ForEach(hotel =>
                {
                    var oldHotel = oldHotels.Where(x => Helper.AreNamesSimilar(x.Name, hotel.Name) || Helper.ObjectsAreEqual<AddressDTO>(hotel.Address,x.Address)).FirstOrDefault();
                    if (oldHotel == null)
                    {
                        var objHotel = _mapper.Map<Hotel>(hotel);
                        _repository.Add(objHotel);
                        _shRepository.Add(new SupplierHotel() { HotelId = objHotel.Id, SupplierId = supplierId });
                        _addressServices.Add(objHotel.Id, hotel.Address);
                    }
                    else
                    {
                        var objHotelSupplier = _shRepository.Find(x => x.SupplierId == supplierId && x.HotelId == oldHotel.Id).FirstOrDefault();
                        if (objHotelSupplier == null)
                            _shRepository.Add(new SupplierHotel() { HotelId = oldHotel.Id, SupplierId = supplierId });
                    }
                });
            }
            else
            {
                NewHotels.ForEach(hotel =>
                {
                    var objHotel = _mapper.Map<Hotel>(hotel);
                    _repository.Add(objHotel);
                    _shRepository.Add(new SupplierHotel() { HotelId = objHotel.Id, SupplierId = supplierId });
                    _addressServices.Add(objHotel.Id, hotel.Address);
                });
            }
            return true;
        }

    }
}
