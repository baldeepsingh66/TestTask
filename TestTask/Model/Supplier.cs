using System.ComponentModel.DataAnnotations;

namespace TestTask.Model
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; } 
        public string SupplierName { get; set; }
    }
}
