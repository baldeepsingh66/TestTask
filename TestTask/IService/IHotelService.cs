using TestTask.DataModel;
using TestTask.DataModel.ResponseDTO;

namespace TestTask.IService
{
    public interface IHotelService
    {
        List<HotelDTO> GetAllHotel();
        bool ConsolidateHotelData(int supplierId, List<HotelDTO> NewHotels);

    }
}
