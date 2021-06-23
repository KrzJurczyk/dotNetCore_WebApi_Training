using System.Collections.Generic;

namespace HotelRooms_REST_EF.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Room> Rooms { get; set; }
    }
}