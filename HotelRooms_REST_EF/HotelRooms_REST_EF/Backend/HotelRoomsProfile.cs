using AutoMapper;
using HotelRooms_REST_EF.Models;

namespace HotelRooms_REST_EF.Backend
{
    public class HotelRoomsProfile : Profile
    {
        public HotelRoomsProfile()
        {
            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Room, RoomDto>().ReverseMap();
        }
    }
}