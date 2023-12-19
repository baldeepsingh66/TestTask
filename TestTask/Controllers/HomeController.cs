using Microsoft.AspNetCore.Mvc;
using TestTask.IService;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IHotelService _hotelService;
        public HomeController(IHotelService hotelService) {
            _hotelService = hotelService;
        }

        [HttpGet("GetAllSuplier")]
        public async Task<IActionResult> GetAllSuplier()
        {
            return Ok(await _hotelService.GetHotelFromSuplier());
        }
    }
}
