using HotelRooms_REST_EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HotelRooms_REST_EF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelRoomsController : ControllerBase
    {
        private readonly ILogger<HotelRoomsController> _logger;

        public HotelRoomsController(ILogger<HotelRoomsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<Room> Get()
        {
            return Content("TO DO");
        }
    }
}