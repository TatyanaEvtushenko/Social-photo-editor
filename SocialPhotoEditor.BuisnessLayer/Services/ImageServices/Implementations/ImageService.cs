using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.BuisnessLayer.Services.CommentServices;
using SocialPhotoEditor.BuisnessLayer.Services.CommentServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.Services.LikeServices;
using SocialPhotoEditor.BuisnessLayer.Services.LikeServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.Services.UserServices;
using SocialPhotoEditor.BuisnessLayer.Services.UserServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.ImageViewModels;
using SocialPhotoEditor.DataLayer.DatabaseModels;
using SocialPhotoEditor.DataLayer.Repositories;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories.Implementations;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.Implementations;
using SociaPhotoEditor.Settings;

namespace SocialPhotoEditor.BuisnessLayer.Services.ImageServices.Implementations
{
    public class ImageService : IImageService
    {
        private static readonly IChangedRepository<Image> ImageRepository = new ImageRepository();
        private static readonly IRepository<Like> LikeRepository = new LikeRepository();
        private static readonly IRepository<Comment> CommentRepository = new CommentRepository();
        private static readonly IRepository<Subscriber> SubscriberRepository = new SubscriberRepository();
        private static readonly IChangedRepository<UserInfo> UserInfoRepository = new UserInfoRepository();

        private static readonly ICommentService CommentService = new CommentService();
        private static readonly ILikeService LikeService = new LikeService();
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
                LikeId = likes.FirstOrDefault(x => x.OwnerId == currentUserName)?.Id,
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
                    LikeId = likes.FirstOrDefault(x => x.OwnerId == currentUserName && x.ImageId == image.FileName)?.Id,
                    LikesCount = likes.Count(x => x.ImageId == image.FileName),
                    Comments = CommentService.GetComments(image.FileName),
                    Owner = UserService.GetUserMinInfo(image.OwnerId)
                });
        }

        public bool DeleteImage(string currentUserName, string imageFileName)
        {
            if (!ImageRepository.Delete(imageFileName)) return false;
            var likes = LikeRepository.GetAll().Where(x => x.ImageId == imageFileName);
            foreach (var like in likes)
            {
                LikeService.DeleteLike(like.Id);
            }
            var comments = CommentRepository.GetAll().Where(x => x.ImageId == imageFileName);
            foreach (var comment in comments)
            {
                CommentService.DeleteComment(comment.Id);
            }
            var info = UserInfoRepository.GetFirst(currentUserName);
            if (info.AvatarFileName != imageFileName) return true;
            info.AvatarFileName = null;
            UserInfoRepository.Update(currentUserName, info);
            return true;
        }

        public string AddImage(string imageFileName)
        {
            throw new System.NotImplementedException();
        }
    }
}
