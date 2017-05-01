using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace SocialPhotoEditor.BuisnessLayer.FileStorage.Implementations
{
    public class CloudinaryStorage : IFileStorage
    {
        private Cloudinary cloudinary;

        public CloudinaryStorage()
        {
            var account = new Account("tantadamcloud", "382595625523566", "kXNP5CO_ozA_qBwDC5ZvyLThAHs");
            cloudinary = new Cloudinary(account);
        }

        public async Task<string> DownloadToStorage(string fileName)
        {
            var param = new ImageUploadParams { File = new FileDescription(fileName) };
            var uploadResult = await cloudinary.UploadAsync(param);
            return uploadResult.Uri.AbsolutePath; 
        }

        public string GetAvatarFileName(string fileName)
        {
            var width = 200;
            var imageCrop = cloudinary.Api.UrlImgUp.Transform(new Transformation().Width(width).Height(width).Crop("fill").Gravity("face").Radius("max")).BuildUrl(fileName);
            return imageCrop;
        }
    }
}