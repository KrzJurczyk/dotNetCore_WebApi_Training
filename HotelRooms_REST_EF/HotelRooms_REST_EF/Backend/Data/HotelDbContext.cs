using HotelRooms_REST_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelRooms_REST_EF.Backend.Data
{
    public class HotelDbContext : DbContext
    {
        private string _connectionString =
                                            @"Server=(localdb)\mssqllocaldb;Database=HotelDb;Trusted_Connection=True;";

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Room> Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().Property(h => h.Name).IsRequired().HasMaxLength(40);
            modelBuilder.Entity<Room>().Property(h => h.Name).IsRequired().HasMaxLength(20);

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