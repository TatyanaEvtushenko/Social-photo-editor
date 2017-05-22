using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace SocialPhotoEditor.BuisnessLayer.Services.FileServices.Implementations
{
    public class CloudinaryService : IFileService
    {
        private static readonly Cloudinary Cloudinary = new Cloudinary(new Account("tantadamcloud", "382595625523566", "kXNP5CO_ozA_qBwDC5ZvyLThAHs"));

        public async Task<string> DownloadToStorage(string fileName)
        {
            var param = new ImageUploadParams { File = new FileDescription(fileName) };
            var uploadResult = await Cloudinary.UploadAsync(param);
            return uploadResult.Uri.AbsolutePath; 
        }

        public string GetAvatarUrl(string fileName)
        {
            var width = 250;
            var imageCrop = Cloudinary.Api.UrlImgUp.Transform(new Transformation().Width(width).Height(width).Crop("fill").Gravity("face").Radius("max")).BuildUrl(fileName);
            return imageCrop;
        }
    }
}