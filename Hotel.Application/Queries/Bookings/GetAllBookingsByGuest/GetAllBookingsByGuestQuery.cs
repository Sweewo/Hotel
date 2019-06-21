using MediatR;
using System.Collections.Generic;

namespace Hotel.Application.Queries.Bookings.GetAllBookingsByGuest
{
    public class GetAllBookingsByGuestQuery : IRequest<IEnumerable<BookingGuestViewModel>>
    {
        public int Id { get; set; }
    }
}
