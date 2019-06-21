using AutoMapper;
using Hotel.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hotel.Application.Queries.RoomTypes.GetAllRoomTypes
{
    public class GetAllRoomTypesQueryHandler : IRequestHandler<GetAllRoomTypesQuery, IEnumerable<RoomTypeViewModel>>
    {
        private readonly IHotelDbContext context;
        private readonly IMapper mapper;

        public GetAllRoomTypesQueryHandler(IHotelDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<RoomTypeViewModel>> Handle(GetAllRoomTypesQuery request, CancellationToken cancellationToken)
        {
            var bookings = await context.RoomTypes
                .ToListAsync();

            var list = mapper.Map<IEnumerable<RoomTypeViewModel>>(bookings);

            return list;
        }
    }
}
