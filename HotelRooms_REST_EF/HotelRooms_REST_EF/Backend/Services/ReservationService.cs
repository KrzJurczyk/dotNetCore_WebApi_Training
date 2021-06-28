using AutoMapper;
using HotelRooms_REST_EF.Backend.Data;
using HotelRooms_REST_EF.Models;
using System.Linq;

namespace HotelRooms_REST_EF.Backend.Services
{
    public class ReservationService : IReservationService
    {
        private readonly HotelDbContext _dbContext;

        private readonly IMapper _mapper;

        public ReservationService(HotelDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Reservation CreateReservation(ReservationDto reservationDto, int roomId)
        {
            var reservation = _mapper.Map<Reservation>(reservationDto);
            reservation.RoomId = roomId;
            _dbContext.Reservations.Add(reservation);
            _dbContext.SaveChanges();

            return reservation;
        }

        public Reservation GetReservationById(int id)
        {
            return _mapper.Map<Reservation>(_dbContext.Reservations.FirstOrDefault(r => r.Id == id));
        }
    }
}