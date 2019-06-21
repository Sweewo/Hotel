using Hotel.Application.Exceptions;
using Hotel.Application.Interfaces;
using Hotel.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hotel.Application.Commands.Rooms.DeleteRoom
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand>
    {
        private readonly IHotelDbContext context;

        public DeleteRoomCommandHandler(IHotelDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Rooms.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Room), request.Id);
            }

            context.Rooms.Remove(entity);

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
