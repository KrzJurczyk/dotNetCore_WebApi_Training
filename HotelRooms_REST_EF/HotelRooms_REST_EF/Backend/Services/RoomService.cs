using AutoMapper;
using HotelRooms_REST_EF.Backend.Data;
using HotelRooms_REST_EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelRooms_REST_EF.Backend.Services
{
    public class RoomService : IRoomService
    {
        private readonly HotelDbContext _dbContext;

        private readonly IMapper _mapper;

        public RoomService(HotelDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Room CreateRoom(int id, RoomDto roomDto)
        {
            var hotel = _dbContext.Hotels.FirstOrDefault(h => h.Id == id);

            if (hotel == null)
                return null;

            var room = _mapper.Map<Room>(roomDto);
            room.HotelId = id;
            _dbContext.Rooms.Add(room);
            _dbContext.SaveChanges();

            return room;
        }

        public bool DeleteRoom(int id)
        {
            var room = _dbContext.Rooms.FirstOrDefault(r => r.Id == id);

            if (room == null)
                return false;

            _dbContext.Rooms.Remove(room);
            _dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<RoomDto> GetAvailableRooms(int hotelId, int beds, int checkIn_YY, int checkIn_MM, int checkIn_DD, int checkOut_YY, int checkOut_MM, int checkOut_DD)
        {
            var rooms = _dbContext.Rooms.Include(r => r.Reservations).Where(r => r.HotelId == hotelId).ToList()
                .Where(r => r.NumberOfBeds == beds && r.Reservations.All(d => IsAvailable(d, checkIn_YY, checkIn_MM, checkIn_DD, checkOut_YY, checkOut_MM, checkOut_DD))).ToList();

            return _mapper.Map<IEnumerable<RoomDto>>(rooms);
        }

        public RoomDto GetRoomById(int id)
        {
            return _mapper.Map<RoomDto>(_dbContext.Rooms.FirstOrDefault(r => r.Id == id));
        }

        public bool UpdateRoom(int id, UpdateRoomDto dto)
        {
            var room = _dbContext.Rooms.FirstOrDefault(h => h.Id == id);

            if (room == null)
                return false;

            room.Name = dto.Name;
            room.NumberOfBeds = dto.NumberOfBeds;

            _dbContext.SaveChanges();

            return true;
        }

        private static bool IsAvailable(Reservation r, int ciy, int cim, int cid, int coy, int com, int cod)
        {
            var checkIn = new DateTime(ciy, cim, cid);
            var checkOut = new DateTime(coy, com, cod);
            var before = checkOut <= r.CheckIn;
            var after = checkIn >= r.CheckOut;

            if (after || before)
                return true;
            return false;
        }
    }
}