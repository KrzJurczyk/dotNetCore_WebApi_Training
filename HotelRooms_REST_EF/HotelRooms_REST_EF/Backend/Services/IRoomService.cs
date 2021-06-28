using HotelRooms_REST_EF.Models;
using System.Collections.Generic;

namespace HotelRooms_REST_EF.Backend.Services
{
    public interface IRoomService
    {
        Room CreateRoom(int id, RoomDto roomDto);

        bool DeleteRoom(int id);

        IEnumerable<RoomDto> GetAvailableRooms(int hotelId, int beds, int checkIn_YY, int checkIn_MM, int checkIn_DD, int checkOut_YY, int checkOut_MM, int checkOut_DD);

        RoomDto GetRoomById(int id);
        bool UpdateRoom(int id, UpdateRoomDto dto);
    }
}