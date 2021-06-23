namespace HotelRooms_REST_EF.Models
{
    public class Room
    {
        public bool Available { get; set; }

        public string CheckIn { get; set; }

        public string CheckOut { get; set; }

        public virtual Hotel Hotel { get; set; }

        public int HotelId { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public int NumberOfBeds { get; set; }
    }
}