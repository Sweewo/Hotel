using Hotel.Domain.Models;
using Hotel.Persistance;
using Microsoft.EntityFrameworkCore;
using System;

namespace Hotel.Application.Tests.Infrastructure
{
    public class HotelContextFactory
    {
        public static HotelDbContext Create()
        {
            var options = new DbContextOptionsBuilder<HotelDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new HotelDbContext(options);

            context.Database.EnsureCreated();

            context.Users.AddRange(new User[] {
                new Guest(new User(){ Id=1,Username="Guest1"}),
                new Guest(new User(){ Id=2,Username="Guest2" }),
                new Manager(new User(){ Id=3,Username="Manager" }){Salary=1000 },
            });

            context.RoomTypes.AddRange(
                new RoomType() { Code = "Single room" },
                new RoomType() { Code = "Double room" }
                );

            context.Rooms.AddRange(
                new Room() { Number = 12, Floor = 1, RoomTypeId = 1 },
                new Room() { Number = 22, Floor = 2, RoomTypeId = 1 },
                new Room() { Number = 23, Floor = 2, RoomTypeId = 2 }
                );

            context.SaveChanges();
            return context;
        }

        public static void Destroy(HotelDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
