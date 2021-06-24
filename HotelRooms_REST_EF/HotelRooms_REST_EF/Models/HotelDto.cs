using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelRooms_REST_EF.Models
{
    public class HotelDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        public string Owner { get; set; }

        public List<RoomDto> Rooms { get; set; }
    }
}