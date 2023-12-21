using AutoMapper;
using TestTask.DataModel;
using TestTask.IService;
using TestTask.Model;
using TestTask.Repository;

namespace TestTask.Service
{
    public class AddressServices: IAddressServices
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;
        public AddressServices(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public AddressDTO Get(int hotelId)
        {
            var address= _repository.Find(x => x.HotelId == hotelId).FirstOrDefault();
            var addressDTO= _mapper.Map<AddressDTO>(address);
            return addressDTO;
        }

        public bool Add(int hotelId, AddressDTO addressDTO)
        {
            var address= _mapper.Map<Address>(addressDTO);
            address.HotelId = hotelId;
            _repository.Add(address);
            return true;
        }
    }
}
