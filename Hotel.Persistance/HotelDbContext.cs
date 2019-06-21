using Hotel.Application.Interfaces;
using Hotel.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Persistance
{
    public class HotelDbContext : DbContext, IHotelDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HotelDbContext).Assembly);
        }
    }
}
