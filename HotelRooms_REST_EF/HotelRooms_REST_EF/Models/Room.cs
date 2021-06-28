using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelRooms_REST_EF.Models
{
    public class Room
    {
        public virtual Hotel Hotel { get; set; }

        public int HotelId { get; set; }

        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        public int NumberOfBeds { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}