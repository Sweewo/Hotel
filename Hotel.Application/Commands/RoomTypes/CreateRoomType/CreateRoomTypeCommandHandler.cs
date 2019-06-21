using AutoMapper;
using Hotel.Application.Interfaces;
using Hotel.Application.Queries.RoomTypes.GetAllRoomTypes;
using Hotel.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hotel.Application.Commands.RoomTypes.CreateRoomType
{
    public class CreateRoomTypeCommandHandler : IRequestHandler<CreateRoomTypeCommand, RoomTypeViewModel>
    {
        private readonly IHotelDbContext context;
        private readonly IMapper mapper;

        public CreateRoomTypeCommandHandler(IHotelDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<RoomTypeViewModel> Handle(CreateRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = new RoomType
            {
                Code = request.Code,
                Cost = request.Cost,
                Categories = request.Categories,
                Facilities = request.Facilities,
                Size = request.Size,
                BedType = request.BedType
            };

            context.RoomTypes.Add(entity);

            await context.SaveChangesAsync(cancellationToken);

            return mapper.Map<RoomTypeViewModel>(entity);
        }
    }
}
