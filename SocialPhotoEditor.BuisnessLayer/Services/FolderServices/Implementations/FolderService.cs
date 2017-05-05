using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.BuisnessLayer.Services.ImageServices;
using SocialPhotoEditor.BuisnessLayer.Services.ImageServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.FolderViewModels;
using SocialPhotoEditor.DataLayer.DatabaseModels;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories.Implementations;

namespace SocialPhotoEditor.BuisnessLayer.Services.FolderServices.Implementations
{
    public class FolderService : IFolderService
    {
        private static readonly IChangedRepository<Folder> FolderRepository = new FolderRepository();

        private static readonly IImageService ImageService = new ImageService();

        public IEnumerable<FolderListViewModel> GetFolderLists(string userName)
        {
            return FolderRepository.GetAll().Where(x => x.OwnerId == userName).Select(x =>
                    new FolderListViewModel
                    {
                        Id = x.Id,
                        ImagesCount = ImageService.GetImageCount(x.Id),
                        Name = x.Name
                    });
        }

        public FolderViewModel GetFolder(string folderId, int imagesCount)
        {
            return new FolderViewModel
            {
                Subscribe = FolderRepository.GetAll().FirstOrDefault(x => x.Id == folderId)?.Subscribe,
                Images = ImageService.GetImageLists(folderId, imagesCount)
            };
        }
    }
}
