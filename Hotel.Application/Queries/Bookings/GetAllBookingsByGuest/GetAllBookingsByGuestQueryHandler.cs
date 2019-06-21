using AutoMapper;
using Hotel.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hotel.Application.Queries.Bookings.GetAllBookingsByGuest
{
    public class GetAllBookingsByGuestQueryHandler : IRequestHandler<GetAllBookingsByGuestQuery, IEnumerable<BookingGuestViewModel>>
    {
        private readonly IHotelDbContext context;
        private readonly IMapper mapper;

        public GetAllBookingsByGuestQueryHandler(IHotelDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<BookingGuestViewModel>> Handle(GetAllBookingsByGuestQuery request, CancellationToken cancellationToken)
        {
            var bookings = await context.Bookings.Include(b => b.Room).ThenInclude(r => r.RoomType)
                .Where(b => b.GuestId.Value.Equals(request.Id))
                .ToListAsync();

            var list = mapper.Map<IEnumerable<BookingGuestViewModel>>(bookings);

            return list;
        }
    }
}
