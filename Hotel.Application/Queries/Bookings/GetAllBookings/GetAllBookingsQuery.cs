using MediatR;
using System.Collections.Generic;

namespace Hotel.Application.Queries.Bookings.GetAllBookings
{
    public class GetAllBookingsQuery:IRequest<IEnumerable<BookingViewModel>>
    {
    }
}
