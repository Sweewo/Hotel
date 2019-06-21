using AutoMapper;
using Hotel.Application.Exceptions;
using Hotel.Application.Interfaces;
using Hotel.Application.Queries.Rooms.GetAllRooms;
using Hotel.Domain.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hotel.Application.Commands.Rooms.CreateRoom
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, RoomViewModel>
    {
        private readonly IHotelDbContext context;
        private readonly IMapper mapper;

        public CreateRoomCommandHandler(IHotelDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<RoomViewModel> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var parent = context.RoomTypes.FirstOrDefault(f => f.Code == request.RoomType);

            if (parent == null)
            {
                throw new NotFoundException(nameof(RoomType), request.RoomType);
            }

            var entity = new Room
            {
                RoomTypeId = parent.Id,
                Floor = request.Floor,
                Number = request.Number
            };

            context.Rooms.Add(entity);

            await context.SaveChangesAsync(cancellationToken);

            return mapper.Map<RoomViewModel>(entity);
        }
    }
}
