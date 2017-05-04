using System.Collections.Generic;
using SocialPhotoEditor.BuisnessLayer.ViewModels.ImageViewModels;

namespace SocialPhotoEditor.BuisnessLayer.Services.ImageServices
{
    public interface IImageService
    {
        int GetPopularity(string userName);

        IEnumerable<ImageListViewModel> GetImageLists(string userName, string folderName);

        int GetImageCount(string folderId);
    }
}
