using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.BuisnessLayer.Services.CommentServices;
using SocialPhotoEditor.BuisnessLayer.Services.CommentServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.Services.UserServices;
using SocialPhotoEditor.BuisnessLayer.Services.UserServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.ImageViewModels;
using SocialPhotoEditor.DataLayer.DatabaseModels;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories.Implementations;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.Implementations;
using SociaPhotoEditor.Settings;

namespace SocialPhotoEditor.BuisnessLayer.Services.ImageServices.Implementations
{
    public class ImageService : IImageService
    {
        private static readonly IChangedRepository<Image> ImageRepository = new ImageRepository();
        private static readonly IEditedRepository<Like> LikeRepository = new LikeRepository();
        private static readonly IEditedRepository<Subscriber> SubscriberRepository = new SubscriberRepository();

        private static readonly ICommentService CommentService = new CommentService();
        private static readonly IUserService UserService = new UserService();

        public ImageViewModel GetImage(string currentUserName, string imageId)
        {
            var image = ImageRepository.GetFirst(imageId);
            if (image == null)
                return null;
            var likes = LikeRepository.GetAll().Where(x => x.ImageId == imageId);
            return new ImageViewModel
            {
                FileName = image.FileName,
                Comments = CommentService.GetComments(imageId),
                LikesCount = likes.Count(),
                IsLiked = likes.FirstOrDefault(x => x.OwnerId == currentUserName) != null,
                Time = image.Time,
                Owner = UserService.GetUserMinInfo(image.OwnerId)
            };
        }

        public IEnumerable<ImageViewModel> GetNews(string currentUserName)
        {
            var subscriptions = SubscriberRepository.GetAll().Where(x => x.SubscriberName == currentUserName).Select(x => x.UserName);
            var images = ImageRepository.GetAll().Where(x => subscriptions.Contains(x.OwnerId)).OrderByDescending(x => x.Time).Take(IntSettings.CountNews);
            var likes = LikeRepository.GetAll();
            return images.Select(image =>
                new ImageViewModel
                {
                    FileName = image.FileName,
                    Time = image.Time,
                    IsLiked = likes.FirstOrDefault(x => x.OwnerId == currentUserName && x.ImageId == image.FileName) != null,
                    LikesCount = likes.Count(x => x.ImageId == image.FileName),
                    Comments = CommentService.GetComments(image.FileName),
                    Owner = UserService.GetUserMinInfo(image.OwnerId)
                });
        }
    }
}
