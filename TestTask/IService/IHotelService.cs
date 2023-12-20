using TestTask.DataModel;
using TestTask.DataModel.ResponseDTO;

namespace TestTask.IService
{
    public interface IHotelService
    {
        Task<TTResponseModel<List<SupplierDTO>>> GetHotelFromSuplier();
    }
}
