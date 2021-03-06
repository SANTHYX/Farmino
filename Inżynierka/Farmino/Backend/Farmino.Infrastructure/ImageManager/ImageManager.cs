using Farmino.Infrastructure.ImageManager.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Farmino.Infrastructure.ImageManager
{
    public class ImageManager : IImageManager
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageManager(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> SaveImage(IFormFile file, string destination)
        {
            if (file == null)
            {
                throw new Exception("Image cannot be empty!");
            }

            var imageName = new String($"{Guid.NewGuid().ToString("N")+Path.GetExtension(file.FileName)}");
            var imagePath = Path.Combine(_webHostEnvironment.ContentRootPath, destination, imageName);

            try
            {
                using(var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

            return imageName;
        }
    }
}
