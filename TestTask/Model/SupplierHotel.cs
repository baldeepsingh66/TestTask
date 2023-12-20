using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Model
{
    public class SupplierHotel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}
