using MediatR;
using Microsoft.AspNetCore.Http;

namespace Hotel.Application.Commands.Users.UploadUserImage
{
    public class UploadUserImageCommand : IRequest<string>
    {
        public int Id { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
