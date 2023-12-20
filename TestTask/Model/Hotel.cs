using System.ComponentModel.DataAnnotations;

namespace TestTask.Model
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
