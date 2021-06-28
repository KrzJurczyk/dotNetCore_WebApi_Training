using HotelRooms_REST_EF.Models;

namespace HotelRooms_REST_EF.Backend.Services
{
    public interface IReservationService
    {
        Reservation CreateReservation(ReservationDto reservationDto, int id);

        Reservation GetReservationById(int id);
    }
}