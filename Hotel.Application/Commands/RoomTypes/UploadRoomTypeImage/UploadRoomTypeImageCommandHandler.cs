using Hotel.Application.Exceptions;
using Hotel.Application.Interfaces;
using Hotel.Application.Interfaces.ImageWriter;
using Hotel.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hotel.Application.Commands.RoomTypes.UploadRoomTypeImage
{
    public class UploadRoomTypeImageCommandHandler : IRequestHandler<UploadRoomTypeImageCommand, string>
    {
        private readonly IHotelDbContext context;
        private readonly IImageWriter imageWriter;

        public UploadRoomTypeImageCommandHandler(IHotelDbContext context, IImageWriter imageWriter)
        {
            this.context = context;
            this.imageWriter = imageWriter;
        }

        public async Task<string> Handle(UploadRoomTypeImageCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.RoomTypes.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(RoomType), request.Id);
            }

            string image = entity.Image;
            if (!string.IsNullOrEmpty(image))
            {
                try
                {
                    await imageWriter.RemoveImage(image);
                }
                catch (Exception)
                {
                    throw new UploadImageException(request.ImageFile.FileName, typeof(IImageWriter));
                }
            }


            try
            {
                image = await imageWriter.UploadImage(request.ImageFile);
            }
            catch (Exception)
            {
                throw new UploadImageException(request.ImageFile.FileName, typeof(IImageWriter));
            }

            entity.Image = image;

            await context.SaveChangesAsync(cancellationToken);

            return image;
        }
    }
}
