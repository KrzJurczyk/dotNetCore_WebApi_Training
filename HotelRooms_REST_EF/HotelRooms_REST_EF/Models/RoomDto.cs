using System.ComponentModel.DataAnnotations;

namespace HotelRooms_REST_EF.Models
{
    public class RoomDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        public int NumberOfBeds { get; set; }
    }
}