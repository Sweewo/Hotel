using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Hotel.Application.Interfaces;
using Hotel.Domain.Models;
using Hotel.Application.Exceptions;
using Hotel.Domain.Enums;
using System;
using Hotel.Application.Queries.Rooms.GetAvailableRooms;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Application.Commands.Bookings.CreateBooking
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, int>
    {
        private readonly IHotelDbContext context;
        private IMediator mediator;
        public CreateBookingCommandHandler(IHotelDbContext context, IMediator mediator)
        {
            this.context = context;
            this.mediator = mediator;
        }

        public async Task<int> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var user = await context.Users.FindAsync(request.Id);

            if (user is null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            var room = context.Rooms.Include(r => r.RoomType).FirstOrDefault(r=>r.Id == request.RoomId);
            if (room is null)
            {
                throw new NotFoundException(nameof(Room), request.RoomId);
            }

            var rooms = mediator.Send(new GetAvailableRoomsQuery() { Code = room.RoomType.Code, In = request.DateFrom, Out = request.DateTo });
            if (!rooms.Result.Any(f => f.Id == request.RoomId))
            {
                throw new NotFoundException(nameof(Room), request.RoomId);
            }

            var entity = new Booking
            {
                DateFrom = request.DateFrom,
                DateTo = request.DateTo,
                RoomId = request.RoomId,
                GuestId = user.UserType is UserType.Guest ? request.Id : (int?)null,
                ManagerId = user.UserType is UserType.Manager ? request.Id : (int?)null,
            };

            try
            {
                context.Bookings.Add(entity);
            }
            catch (Exception) { }

            await context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
