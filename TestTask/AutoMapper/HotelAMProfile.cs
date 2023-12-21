using AutoMapper;
using TestTask.DataModel;
using TestTask.Model;

namespace TestTask.AutoMapper
{
    public class HotelAMProfile : Profile
    {
        public HotelAMProfile()
        {
            CreateMap<Hotel, HotelDTO>();
        }
    }
}
