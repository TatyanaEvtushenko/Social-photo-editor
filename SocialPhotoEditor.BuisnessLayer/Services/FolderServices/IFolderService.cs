using System.Collections.Generic;
using SocialPhotoEditor.BuisnessLayer.ViewModels.FolderViewModels;
using SocialPhotoEditor.BuisnessLayer.ViewModels.ImageViewModels;

namespace SocialPhotoEditor.BuisnessLayer.Services.FolderServices
{
    public interface IFolderService
    {
        IEnumerable<FolderListViewModel> GetFolderLists(string userName);

        FolderViewModel GetFolder(string folderId);

        IEnumerable<ImageListViewModel> GetMoreImages(int pageNumber, string folderId);
    }
}
