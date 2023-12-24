using Microsoft.AspNetCore.Mvc;
using TestTask.IService;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IHotelService _hotelService;
        private readonly ISupplierService _supplierService;
        public HomeController(IHotelService hotelService, ISupplierService supplierService)
        {
            _hotelService = hotelService;
            _supplierService = supplierService;
        }

        [HttpGet("GetAllSuplier")]
        public async Task<IActionResult> GetAllSuplier()
        {
            return Ok(_supplierService.GetHotelFromSuplier());
        }
    }
}
