using MediatR;
using Microsoft.AspNetCore.Http;

namespace Hotel.Application.Commands.RoomTypes.UploadRoomTypeImage
{
    public class UploadRoomTypeImageCommand : IRequest<string>
    {
        public int Id { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
