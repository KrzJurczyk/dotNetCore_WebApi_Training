using HotelRooms_REST_EF.Backend.Services;
using HotelRooms_REST_EF.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelRooms_REST_EF.Controllers
{
    [ApiController]
    [Route("api/hotelrooms/reservation")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _service;

        public ReservationController(IReservationService service)
        {
            _service = service;
        }

        [HttpPost("{roomId}")]
        public async Task<ActionResult> CreateReservation([FromBody] ReservationDto reservationDto, [FromRoute] int roomId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reservation = _service.CreateReservation(reservationDto, roomId);

            if (reservation == null)
                NotFound();

            return Created($"api/hotelrooms/reservation/{reservation.Id}", null);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> Get([FromRoute] int id)
        {
            var reservation = _service.GetReservationById(id);
            return reservation != null ? Ok(reservation) : NotFound();
        }
    }
}