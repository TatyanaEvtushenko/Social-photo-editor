using System.Collections.Generic;
using SocialPhotoEditor.BuisnessLayer.ViewModels.FolderViewModels;

namespace SocialPhotoEditor.BuisnessLayer.Services.FolderServices
{
    public interface IFolderService
    {
        IEnumerable<FolderListViewModel> GetFolderLists(string userName);

        FolderViewModel GetFolder(string folderId, int imagesCount);
    }
}
