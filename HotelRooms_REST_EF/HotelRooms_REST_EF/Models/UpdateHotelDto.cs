using System.ComponentModel.DataAnnotations;

namespace HotelRooms_REST_EF.Models
{
    public class UpdateHotelDto
    {
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        public string Owner { get; set; }
    }
}