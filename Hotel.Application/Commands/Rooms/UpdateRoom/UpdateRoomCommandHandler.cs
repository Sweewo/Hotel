using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Hotel.Application.Exceptions;
using Hotel.Application.Interfaces;
using Hotel.Application.Queries.Rooms.GetAllRooms;
using Hotel.Domain.Models;
using MediatR;

namespace Hotel.Application.Commands.Rooms.UpdateRoom
{
    class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, RoomViewModel>
    {
        private readonly IHotelDbContext context;
        private readonly IMapper mapper;

        public UpdateRoomCommandHandler(IHotelDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<RoomViewModel> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var parent = context.RoomTypes.FirstOrDefault(e => e.Code == request.RoomType);

            var entity = await context.Rooms.FindAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Room), request.Id);
            }

            entity.RoomType = parent ?? throw new NotFoundException(nameof(RoomType), request.RoomType);
            entity.Number = request.Number;
            entity.Floor = request.Floor;

            await context.SaveChangesAsync(cancellationToken);

            return mapper.Map<RoomViewModel>(entity);
        }

    }
}
