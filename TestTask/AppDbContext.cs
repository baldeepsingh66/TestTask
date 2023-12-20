using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using TestTask.Model;

namespace TestTask
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public Supplier Suppliers { get; set; }
        public SupplierHotel SupplierHotels { get; set; }
        public Hotel Hotels { get; set; }
        public Address Addresses { get; set; }
    }
}
