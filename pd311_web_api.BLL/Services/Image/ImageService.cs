using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace pd311_web_api.BLL.Services.Image
{
    public class ImageService : IImageService
    {
        public bool DeleteImage(string imagePath)
        {
            try
            {
                var imagesPath = Path.Combine(Settings.RootPath, "wwwroot", Settings.RootImagesPath);
                imagePath = Path.Combine(imagesPath, imagePath);

                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }

        public async Task<string?> SaveImageAsync(IFormFile image, string directoryPath)
        {
            try
            {
                var types = image.ContentType.Split("/");

                if (types[0] != "image")
                {
                    return null;
                }

                var imagesPath = Path.Combine(Settings.RootPath, "wwwroot", Settings.RootImagesPath);
                var imageName = $"{Guid.NewGuid()}.{types[1]}";

                var imagePath = Path.Combine(imagesPath, directoryPath, imageName);

                using (var stream = File.Create(imagePath))
                {
                    await image.CopyToAsync(stream);
                }

                return imageName;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
