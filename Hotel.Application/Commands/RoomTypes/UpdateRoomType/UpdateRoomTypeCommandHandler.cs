using AutoMapper;
using Hotel.Application.Exceptions;
using Hotel.Application.Interfaces;
using Hotel.Application.Queries.RoomTypes.GetAllRoomTypes;
using Hotel.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hotel.Application.Commands.RoomTypes.UpdateRoomType
{
    public class UpdateRoomTypeCommandHandler : IRequestHandler<UpdateRoomTypeCommand, RoomTypeViewModel>
    {
        private readonly IHotelDbContext context;
        private readonly IMapper mapper;

        public UpdateRoomTypeCommandHandler(IHotelDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<RoomTypeViewModel> Handle(UpdateRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.RoomTypes.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(RoomType), request.Id);
            }

            entity.Code = request.Code;
            entity.Cost = request.Cost;
            entity.Categories = request.Categories;
            entity.Facilities = request.Facilities;
            entity.Size = request.Size;
            entity.BedType = request.BedType;

            await context.SaveChangesAsync(cancellationToken);

            return mapper.Map<RoomTypeViewModel>(entity);
        }
    }
}
