using System.Threading.Tasks;

namespace SocialPhotoEditor.BuisnessLayer.Services.FileServices
{
    public interface IFileService
    {
        Task<string> DownloadToStorage(string fileName);

        void RemoveFromStorage(string fileName);
    }
}
