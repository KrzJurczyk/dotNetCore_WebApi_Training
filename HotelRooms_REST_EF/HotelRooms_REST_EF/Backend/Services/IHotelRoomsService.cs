using HotelRooms_REST_EF.Models;
using System.Collections.Generic;

namespace HotelRooms_REST_EF.Backend.Services
{
    public interface IHotelRoomsService
    {
        Hotel CreateHotel(HotelDto hotelDto);

        Room CreateRoom(int id, RoomDto roomDto);

        bool DeleteHotel(int id);

        bool DeleteRoom(int id);

        HotelDto GetHotelById(int id);

        IEnumerable<HotelDto> GetHotels();

        bool UpdateHotel(int id, UpdateHotelDto dto);

        bool UpdateRoom(int id, UpdateRoomDto dto);
    }
}