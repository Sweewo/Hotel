using AutoMapper;
using Hotel.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hotel.Application.Queries.Bookings.GetAllBookings
{
    public class GetAllBookingsQueryHandler : IRequestHandler<GetAllBookingsQuery, IEnumerable<BookingViewModel>>
    {
        private readonly IHotelDbContext context;
        private readonly IMapper mapper;

        public GetAllBookingsQueryHandler(IHotelDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<BookingViewModel>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
        {
            var bookings = await context.Bookings.Include(b => b.Guest).Include(b => b.Manager).Include(b => b.Room).ThenInclude(r => r.RoomType).ToListAsync();

            var list = mapper.Map<IEnumerable<BookingViewModel>>(bookings);

            return list;
        }
    }
}
