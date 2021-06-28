using HotelRooms_REST_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelRooms_REST_EF.Backend.Data
{
    public class HotelSeeder
    {
        private readonly HotelDbContext _dbContext;

        public HotelSeeder(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (!_dbContext.Database.CanConnect() || _dbContext.Hotels.Any())
                return;

            _dbContext.Hotels.AddRange(GetData());
            _dbContext.SaveChanges();
        }

        private static Hotel CreateHotel(string name)
        {
            return new Hotel()
            {
                Name = name,
                Rooms = new List<Room>()
                {
                    CreateRoom($"{name}_1", 2),
                    CreateRoom($"{name}_2", 4),
                }
            };
        }

        private static Reservation CreateReservation(string name)
        {
            var dt = DateTime.Today;
            return new Reservation()
            {
                Name = name + "_reservation",
                CheckIn = dt,
                CheckOut = dt
            };
        }

        private static Room CreateRoom(string name, int beds)
        {
            return new Room()
            {
                Name = name,
                NumberOfBeds = beds,
                Reservations = new List<Reservation>()
                {
                    CreateReservation(name)
                }
            };
        }
        private static IEnumerable<Hotel> GetData()
        {
            return new List<Hotel>()
            {
                CreateHotel("HotelRed"),
                CreateHotel("HotelBlue")
            };
        }
    }
}