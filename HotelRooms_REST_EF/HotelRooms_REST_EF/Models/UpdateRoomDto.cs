using System.ComponentModel.DataAnnotations;

namespace HotelRooms_REST_EF.Models
{
    public class UpdateRoomDto
    {
        public bool Available { get; set; }

        public string CheckIn { get; set; }

        public string CheckOut { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        public int NumberOfBeds { get; set; }
    }
}