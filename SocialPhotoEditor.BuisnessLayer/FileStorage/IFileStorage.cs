using System.Threading.Tasks;

namespace SocialPhotoEditor.BuisnessLayer.FileStorage
{
    interface IFileStorage
    {
        Task<string> DownloadToStorage(string fileName);
    }
}
