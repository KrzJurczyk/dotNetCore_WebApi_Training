using HotelRooms_REST_EF.Models;
using System.Collections.Generic;

namespace HotelRooms_REST_EF.Backend.Services
{
    public interface IHotelRoomsService
    {
        Hotel CreateHotel(HotelDto hotelDto);

        bool DeleteHotel(int id);

        HotelDto GetHotelById(int id);

        IEnumerable<HotelDto> GetHotels();

        bool UpdateHotel(int id, UpdateHotelDto dto);
    }
}