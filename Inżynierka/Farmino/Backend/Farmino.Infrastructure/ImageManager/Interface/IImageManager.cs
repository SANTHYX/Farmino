using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Farmino.Infrastructure.ImageManager.Interface
{
    public interface IImageManager
    {
        Task<string> SaveImage(IFormFile file, string destination);
    }
}
