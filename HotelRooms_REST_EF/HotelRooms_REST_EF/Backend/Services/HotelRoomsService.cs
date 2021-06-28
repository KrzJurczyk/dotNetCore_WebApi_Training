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

        public bool DeleteHotel(int id)
        {
            var hotel = _dbContext.Hotels.FirstOrDefault(h => h.Id == id);

            if (hotel == null)
                return false;

            _dbContext.Hotels.Remove(hotel);
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
    }
}