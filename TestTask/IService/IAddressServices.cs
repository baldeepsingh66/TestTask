using TestTask.DataModel;
using TestTask.Model;

namespace TestTask.IService
{
    public interface IAddressServices
    {
        public AddressDTO Get(int hotelId);
    }
}
