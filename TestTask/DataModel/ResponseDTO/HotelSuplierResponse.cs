namespace TestTask.DataModel.ResponseDTO
{
    public class HotelSuplierResponse
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set;}
        public List<Hotels> Hotels { get; set;}
    }
}
