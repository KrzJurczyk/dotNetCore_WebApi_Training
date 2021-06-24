using AutoMapper;
using HotelRooms_REST_EF.Backend.Data;
using HotelRooms_REST_EF.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HotelRooms_REST_EF.Backend.Services
{
    public class HotelRoomsService : IHotelRoomsService
    {
        private readonly HotelDbContext _dbContext;

        private readonly IMapper _mapper;

        public HotelRoomsService(HotelDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Hotel CreateHotel(HotelDto hotelDto)
        {
            var hotel = _mapper.Map<Hotel>(hotelDto);
            _dbContext.Hotels.Add(hotel);
            _dbContext.SaveChanges();

            return hotel;
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

        public bool DeleteHotel(int id)
        {
            var hotel = _dbContext.Hotels.FirstOrDefault(h => h.Id == id);

            if (hotel == null)
                return false;

            _dbContext.Hotels.Remove(hotel);
            _dbContext.SaveChanges();
            return true;
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

        public HotelDto GetHotelById(int id)
        {
            return _mapper.Map<HotelDto>(_dbContext.Hotels.Include(r => r.Rooms).FirstOrDefault(h => h.Id == id));
        }

        public IEnumerable<HotelDto> GetHotels()
        {
            return _mapper.Map<IEnumerable<HotelDto>>(_dbContext.Hotels.Include(r => r.Rooms).ToList());
        }

        public bool UpdateHotel(int id, UpdateHotelDto dto)
        {
            var hotel = _dbContext.Hotels.FirstOrDefault(h => h.Id == id);

            if (hotel == null)
                return false;

            hotel.Name = dto.Name;
            hotel.Owner = dto.Owner;

            _dbContext.SaveChanges();

            return true;
        }

        public bool UpdateRoom(int id, UpdateRoomDto dto)
        {
            var room = _dbContext.Rooms.FirstOrDefault(h => h.Id == id);

            if (room == null)
                return false;

            room.Available = dto.Available;
            room.CheckIn = dto.CheckIn;
            room.CheckOut = dto.CheckOut;
            room.Name = dto.Name;
            room.NumberOfBeds = dto.NumberOfBeds;

            _dbContext.SaveChanges();

            return true;
        }
    }
}