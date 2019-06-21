using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Hotel.Application.Interfaces.ImageWriter
{
    public interface IImageWriter
    {
        Task<string> UploadImage(IFormFile file);
        Task RemoveImage(string fileName);
    }
}
