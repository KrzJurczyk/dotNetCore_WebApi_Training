using HotelRooms_REST_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelRooms_REST_EF.Backend.Data
{
    public class HotelDbContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().Property(h => h.Name).IsRequired().HasMaxLength(40);
            modelBuilder.Entity<Room>().Property(r => r.Name).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Reservation>().Property(r => r.Name).IsRequired().HasMaxLength(60);
            modelBuilder.Entity<Reservation>().Property(r => r.CheckIn).IsRequired();
            modelBuilder.Entity<Reservation>().Property(r => r.CheckOut).IsRequired();

            // Requires additional migration ect, better to use a HotelSeeder
            //modelBuilder.Entity<Hotel>().HasData(
            //    new Hotel() { Id = 1, Name = "Hotel Red" },
            //    new Hotel() { Id = 2, Name = "Hotel Blue" });
            //modelBuilder.Entity<Room>().HasData(
            //    new Room() { Id = 1, Name = "1", Available = true, CheckIn = "", CheckOut = "", HotelId = 1, NumberOfBeds = 2 },
            //    new Room() { Id = 2, Name = "2", Available = true, CheckIn = "", CheckOut = "", HotelId = 1, NumberOfBeds = 4 },
            //    new Room() { Id = 3, Name = "22B", Available = true, CheckIn = "", CheckOut = "", HotelId = 2, NumberOfBeds = 6 });
        }
    }
}