using System.Threading.Tasks;

namespace SocialPhotoEditor.BuisnessLayer.Services.FileServices
{
    interface IFileService
    {
        Task<string> DownloadToStorage(string fileName);

        string GetAvatarUrl(string fileName);
    }
}
