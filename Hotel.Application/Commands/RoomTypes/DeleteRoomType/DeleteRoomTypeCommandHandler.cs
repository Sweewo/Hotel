using Hotel.Application.Exceptions;
using Hotel.Application.Interfaces;
using Hotel.Application.Interfaces.ImageWriter;
using Hotel.Domain.Models;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hotel.Application.Commands.RoomTypes.DeleteRoomType
{
    public class DeleteRoomTypeCommandHandler : IRequestHandler<DeleteRoomTypeCommand>
    {
        private readonly IHotelDbContext context;
        private readonly IImageWriter imageWriter;

        public DeleteRoomTypeCommandHandler(IHotelDbContext context, IImageWriter imageWriter)
        {
            this.context = context;
            this.imageWriter = imageWriter;
        }

        public async Task<Unit> Handle(DeleteRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.RoomTypes.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(RoomType), request.Id);
            }

            var hasRooms = context.Rooms.FirstOrDefault(od => od.RoomTypeId == entity.Id);
            if (hasRooms != null)
            {
                throw new DeleteFailureException(nameof(RoomType), "There are existing rooms associated with this room type.");
            }

            if (!string.IsNullOrEmpty(entity.Image))
            {
                try
                {
                    await imageWriter.RemoveImage(entity.Image);
                }
                catch (Exception)
                {
                    throw new UploadImageException(entity.Image, typeof(IImageWriter));
                }
            }

            context.RoomTypes.Remove(entity);

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
