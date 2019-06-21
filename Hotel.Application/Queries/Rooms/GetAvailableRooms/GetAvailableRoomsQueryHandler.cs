using AutoMapper;
using Hotel.Application.Interfaces;
using Hotel.Application.Queries.Rooms.GetAllRooms;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hotel.Application.Queries.Rooms.GetAvailableRooms
{
    public class GetAvailableRoomsQueryHandler : IRequestHandler<GetAvailableRoomsQuery, IEnumerable<RoomViewModel>>
    {
        private readonly IHotelDbContext context;
        private readonly IMapper mapper;

        public GetAvailableRoomsQueryHandler(IHotelDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<RoomViewModel>> Handle(GetAvailableRoomsQuery request, CancellationToken cancellationToken)
        {
            var rooms = await context.Rooms
                .Include(r => r.RoomType).Include(r => r.Bookings)
                .Where(r => r.RoomType.Code.Equals(request.Code))
                .Where(r => r.Bookings.Where(b =>
                                (request.In <= b.DateFrom && request.Out >= b.DateTo) ||
                                (request.In >= b.DateFrom && request.Out <= b.DateTo) ||
                                (request.In <= b.DateFrom && request.Out <= b.DateTo && request.Out > b.DateFrom) ||
                                (request.In >= b.DateFrom && request.Out >= b.DateTo && request.In < b.DateTo)
                                ).Count() == 0)
                .ToListAsync();

            var list = mapper.Map<IEnumerable<RoomViewModel>>(rooms);

            return list;
        }
    }
}
