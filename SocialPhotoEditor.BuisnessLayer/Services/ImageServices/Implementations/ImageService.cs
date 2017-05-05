using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.BuisnessLayer.Services.CommentServices;
using SocialPhotoEditor.BuisnessLayer.Services.CommentServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.Services.LikeServices;
using SocialPhotoEditor.BuisnessLayer.Services.LikeServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.ImageViewModels;
using SocialPhotoEditor.DataLayer.DatabaseModels;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories.Implementations;

namespace SocialPhotoEditor.BuisnessLayer.Services.ImageServices.Implementations
{
    public class ImageService : IImageService
    {
        private static readonly IChangedRepository<Image> ImageRepository = new ImageRepository();

        private static readonly ILikeService LikeService = new LikeService();
        private static readonly ICommentService CommentService = new CommentService();

        public int GetPopularity(string userName)
        {
            var images = ImageRepository.GetAll().Where(x => x.OwnerId == userName).ToList();
            if (!images.Any())
            {
                return 0;
            }
            var likesCount = images.Sum(image => LikeService.GetLikesCount(image.FileName));
            return likesCount / images.Count();
        }

        public IEnumerable<ImageListViewModel> GetImageLists(string folderId, int count)
        {
            var images = ImageRepository.GetAll();
            var imagesInFolder = images.Where(x => x.FolderId == folderId);
            if (!imagesInFolder.Any())
                imagesInFolder = images.Where(x => x.OwnerId == folderId);
            return imagesInFolder.Take(count).Select(x => new ImageListViewModel
            {
                FileName = x.FileName,
                CommentsCount = CommentService.GetCommentsCount(x.FileName),
                LikesCount = LikeService.GetLikesCount(x.FileName),
            });
        }

        public int GetImageCount(string folderId)
        {
            return ImageRepository.GetAll().Count(x => x.FolderId == folderId);
        }

        public ImageViewModel GetImage(string imageId)
        {
            var image = ImageRepository.GetAll().FirstOrDefault(x => x.FileName == imageId);
            if (image == null) return null;
            return new ImageViewModel
            {
                FileName = image.FileName,
                Comments = CommentService.GetComments(imageId),
                LikesCount = LikeService.GetLikesCount(imageId),
                Time = image.Time
            };
        }
    }
}
