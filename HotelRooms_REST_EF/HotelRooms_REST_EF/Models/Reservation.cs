﻿using System;
using System.ComponentModel.DataAnnotations;

namespace HotelRooms_REST_EF.Models
{
    public class Reservation
    {
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime CheckOut { get; set; }

        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        public virtual Room Room { get; set; }

        public int RoomId { get; set; }
    }
}