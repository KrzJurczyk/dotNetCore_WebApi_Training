using HotelRooms_REST_EF.Backend.Services;
using HotelRooms_REST_EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace HotelRooms_REST_EF.Controllers
{
    [ApiController]
    [Route("api/hotelrooms")]
    public class HotelRoomsController : ControllerBase
    {
        private readonly ILogger<HotelRoomsController> _logger;

        private readonly IHotelRoomsService _service;

        public HotelRoomsController(ILogger<HotelRoomsController> logger, IHotelRoomsService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public ActionResult CreateHotel([FromBody] HotelDto hotelDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var hotel = _service.CreateHotel(hotelDto);

            return Created($"api/hotelrooms/{hotel.Id}", null);
        }

        [HttpPost("{id}")]
        public ActionResult CreateRoom([FromRoute] int id, [FromBody] RoomDto roomDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var room = _service.CreateRoom(id, roomDto);
            if (room == null)
                NotFound();

            return Created($"api/hotelrooms/{id}/{room.Id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteHotel([FromRoute] int id)
        {
            return _service.DeleteHotel(id) ? NoContent() : NotFound();
        }

        [HttpDelete("room/{id}")]
        public ActionResult DeleteRoom([FromRoute] int id)
        {
            return _service.DeleteRoom(id) ? NoContent() : NotFound();
        }

        [HttpGet]
        public ActionResult<IEnumerable<HotelDto>> Get()
        {
            return Ok(_service.GetHotels());
        }

        [HttpGet("{id}")]
        public ActionResult<HotelDto> Get([FromRoute] int id)
        {
            var hotel = _service.GetHotelById(id); ;
            return hotel != null ? Ok(hotel) : NotFound();
        }

        [HttpGet("room/{id}")]
        public ActionResult<RoomDto> GetRoom([FromRoute] int id)
        {
            return Ok(_service.GetRoomById(id));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateHotel([FromRoute] int id, [FromBody] UpdateHotelDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return _service.UpdateHotel(id, dto) ? Ok() : NotFound();
        }

        [HttpPut("room/{id}")]
        public ActionResult UpdateRoom([FromRoute] int id, [FromBody] UpdateRoomDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return _service.UpdateRoom(id, dto) ? Ok() : NotFound();
        }
    }
}