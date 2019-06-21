using Hotel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Hotel.Application.Interfaces
{
    public interface IHotelDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Manager> Managers { get; set; }
        DbSet<Guest> Guests { get; set; }
        DbSet<RoomType> RoomTypes { get; set; }
        DbSet<Room> Rooms { get; set; }
        DbSet<Booking> Bookings { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
