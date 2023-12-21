using TestTask.DataModel.ResponseDTO;
using TestTask.DataModel;

namespace TestTask.IService
{
    public interface ISupplierService
    {
        Task<TTResponseModel<List<SupplierDTO>>> GetHotelFromSuplier();

    }
}
