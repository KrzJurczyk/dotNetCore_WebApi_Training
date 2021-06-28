using HotelRooms_REST_EF.Backend.Services;
using HotelRooms_REST_EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace HotelRooms_REST_EF.Controllers
{
    [ApiController]
    [Route("api/hotelrooms/rooms")]
    public class RoomController : ControllerBase
    {
        private readonly ILogger<HotelRoomsController> _logger;

        private readonly IRoomService _service;

        public RoomController(ILogger<HotelRoomsController> logger, IRoomService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost("{id}")]
        public ActionResult CreateRoom([FromRoute] int id, [FromBody] RoomDto roomDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var room = _service.CreateRoom(id, roomDto);
            if (room == null)
                NotFound();

            return Created($"api/hotelrooms/rooms/{room.Id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRoom([FromRoute] int id)
        {
            return _service.DeleteRoom(id) ? NoContent() : NotFound();
        }

        [HttpGet("find/{hotelId}")]
        public ActionResult<IEnumerable<RoomDto>> GetAvailableRooms(int hotelId, int beds, int checkIn_YY, int checkIn_MM, int checkIn_DD, int checkOut_YY, int checkOut_MM, int checkOut_DD)
        {
            return Ok(_service.GetAvailableRooms(hotelId, beds, checkIn_YY, checkIn_MM, checkIn_DD, checkOut_YY, checkOut_MM, checkOut_DD));
        }

        [HttpGet("{id}")]
        public ActionResult<RoomDto> GetRoom([FromRoute] int id)
        {
            return Ok(_service.GetRoomById(id));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateRoom([FromRoute] int id, [FromBody] UpdateRoomDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return _service.UpdateRoom(id, dto) ? Ok() : NotFound();
        }
    }
}