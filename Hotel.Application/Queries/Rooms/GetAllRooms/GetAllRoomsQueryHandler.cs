using AutoMapper;
using Hotel.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hotel.Application.Queries.Rooms.GetAllRooms
{
    public class GetAllRoomsQueryHandler : IRequestHandler<GetAllRoomsQuery, IEnumerable<RoomViewModel>>
    {
        private readonly IHotelDbContext context;
        private readonly IMapper mapper;

        public GetAllRoomsQueryHandler(IHotelDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<RoomViewModel>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
        {
            var rooms = await context.Rooms.Include(r => r.RoomType)
                .ToListAsync();

            var list = mapper.Map<IEnumerable<RoomViewModel>>(rooms);

            return list;
        }
    }
}
