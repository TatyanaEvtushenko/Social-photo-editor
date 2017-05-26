using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace SocialPhotoEditor.BuisnessLayer.Services.FileServices.Implementations
{
    public class CloudinaryService : IFileService
    {
        private static readonly Cloudinary Cloudinary = new Cloudinary(new Account("tantadamcloud", "382595625523566", "kXNP5CO_ozA_qBwDC5ZvyLThAHs"));

        private Transformation GetSquareAvatarTransformation(string fileName)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Open))
            {
                var image = Image.FromStream(fileStream);
                var width = image.Width < image.Height ? image.Width : image.Height;
                return new Transformation().Width(width).Height(width).Crop("fill").Gravity("face");
            }
        }

        public async Task<string> DownloadToStorage(string fileName)
        {
            var fileInfo = new FileInfo(fileName);
            if (!fileInfo.Exists) return null;
            var param = new ImageUploadParams
            {
                File = new FileDescription(fileName),
                Transformation = GetSquareAvatarTransformation(fileName)
            };
            var imageInStorage = await Cloudinary.UploadAsync(param);
            fileInfo.Delete();
            return imageInStorage.Uri.AbsoluteUri;
        }
    }
}