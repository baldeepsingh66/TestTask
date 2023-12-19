using TestTask.DataModel.ResponseDTO;

namespace TestTask.IService
{
    public interface IHotelService
    {
        Task<TTResponseModel<List<HotelSuplierResponse>>> GetHotelFromSuplier();
    }
}
