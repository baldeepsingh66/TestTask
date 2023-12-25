using AutoMapper;
using TestTask.DataModel;
using TestTask.Model;

namespace TestTask.AutoMapper
{
    public class AddressAMProfile: Profile
    {
        public AddressAMProfile()
        {
            CreateMap<AddressDTO,Address>();
            CreateMap<Address, AddressDTO>().ForMember(m=>m.Id, opt=>opt.Ignore());
        }
    }
}
