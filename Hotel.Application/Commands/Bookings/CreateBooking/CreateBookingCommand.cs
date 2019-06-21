using MediatR;
using System;

namespace Hotel.Application.Commands.Bookings.CreateBooking
{
    public class CreateBookingCommand : IRequest<int>
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int RoomId { get; set; }
        public int Id { get; set; }
    }
}
