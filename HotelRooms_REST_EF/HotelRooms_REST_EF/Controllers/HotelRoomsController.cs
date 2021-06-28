using HotelRooms_REST_EF.Backend.Services;
using HotelRooms_REST_EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelRooms_REST_EF.Controllers
{
    [ApiController]
    [Route("api/hotelrooms")]
    public class HotelRoomsController : Controller
    {
        private readonly ILogger<HotelRoomsController> _logger;

        private readonly IHotelRoomsService _service;

        public HotelRoomsController(ILogger<HotelRoomsController> logger, IHotelRoomsService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> CreateHotel([FromBody] HotelDto hotelDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var hotel = _service.CreateHotel(hotelDto);

            return Created($"api/hotelrooms/{hotel.Id}", null);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHotel([FromRoute] int id)
        {
            return _service.DeleteHotel(id) ? NoContent() : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDto>>> Get()
        {
            return Ok(_service.GetHotels());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDto>> Get([FromRoute] int id)
        {
            var hotel = _service.GetHotelById(id); ;
            return hotel != null ? Ok(hotel) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHotel([FromRoute] int id, [FromBody] UpdateHotelDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return _service.UpdateHotel(id, dto) ? Ok() : NotFound();
        }
    }
}