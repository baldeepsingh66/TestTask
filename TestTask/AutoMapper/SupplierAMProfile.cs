using AutoMapper;
using TestTask.DataModel;
using TestTask.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TestTask.AutoMapper
{
    public class SupplierAMProfile : Profile
    {
        public SupplierAMProfile()
        {
            CreateMap<SupplierDTO, Supplier>();
        }
    }
}
