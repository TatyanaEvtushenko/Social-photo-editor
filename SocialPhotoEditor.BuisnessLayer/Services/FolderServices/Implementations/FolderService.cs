using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.BuisnessLayer.Services.CommentServices;
using SocialPhotoEditor.BuisnessLayer.Services.CommentServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.Services.LikeServices;
using SocialPhotoEditor.BuisnessLayer.Services.LikeServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.FolderViewModels;
using SocialPhotoEditor.BuisnessLayer.ViewModels.ImageViewModels;
using SocialPhotoEditor.DataLayer.DatabaseModels;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories.Implementations;
using SociaPhotoEditor.Settings;

namespace SocialPhotoEditor.BuisnessLayer.Services.FolderServices.Implementations
{
    public class FolderService : IFolderService
    {
        private static readonly IChangedRepository<Folder> FolderRepository = new FolderRepository();
        private static readonly IChangedRepository<Image> ImageRepository = new ImageRepository();

        private static readonly ICommentService CommentService = new CommentService();
        private static readonly ILikeService LikeService = new LikeService();

        public IEnumerable<FolderListViewModel> GetFolderLists(string userName)
        {
            return FolderRepository.GetAll().Where(x => x.OwnerId == userName).Select(x =>
                new FolderListViewModel
                {
                    Id = x.Id,
                    ImagesCount = ImageRepository.GetAll().Count(image => image.FolderId == x.Id),
                    Name = x.Name
                });
        }

        public FolderViewModel GetFolder(string folderId)
        {
            var folderModel = FolderRepository.GetFirst(folderId);
            return new FolderViewModel
            {
                Subscribe = folderModel?.Subscribe,
                Name = folderModel?.Name,
                Id = folderId,
                Images = GetMoreImagesFromFolder(0, folderId),
                OwnerId = folderModel?.OwnerId
            };
        }

        public IEnumerable<ImageListViewModel> GetMoreImagesFromFolder(int pageNumber, string folderId)
        {
            var images = ImageRepository.GetAll().Where(x => x.FolderId == folderId);
            return GetMoreAnyImages(pageNumber, images);
        }

        public IEnumerable<ImageListViewModel> GetMoreUserImages(int pageNumber, string userName)
        {
            var images = ImageRepository.GetAll().Where(x => x.OwnerId == userName);
            return GetMoreAnyImages(pageNumber, images);
        }

        private static IEnumerable<ImageListViewModel> GetMoreAnyImages(int pageNumber, IEnumerable<Image> images)
        {
            var countOnPage = IntSettings.CountImageLists;
            return images.OrderByDescending(x => x.Time).Skip(countOnPage * pageNumber).Take(countOnPage).Select(x => new ImageListViewModel
            {
                FileName = x.FileName,
                CommentsCount = CommentService.GetCommentsCount(x.FileName),
                LikesCount = LikeService.GetLikesCount(x.FileName),
                CreatingTime = x.Time
            });
        }

        public string AddFolder(string name, string subscribe, string currentUserName, string ownerUserName)
        {
            if (ownerUserName != currentUserName) return null;
            var folder = new Folder {Name = name, Subscribe = subscribe, OwnerId = currentUserName};
            return FolderRepository.Add(folder);
        }

        public bool DeleteFolder(string folderId, string currentUserName)
        {
            if (FolderRepository.GetFirst(folderId).OwnerId != currentUserName) return false;
            if (!FolderRepository.Delete(folderId)) return false;
            var images = ImageRepository.GetAll().Where(x => x.FolderId == folderId);
            foreach (var image in images)
            {
                image.FolderId = null;
                ImageRepository.Update(image.FileName, image);
            }
            return true;
        }
    }
}
