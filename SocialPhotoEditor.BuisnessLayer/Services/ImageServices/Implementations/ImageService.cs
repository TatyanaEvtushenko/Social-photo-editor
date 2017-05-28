using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.BuisnessLayer.Services.CommentServices;
using SocialPhotoEditor.BuisnessLayer.Services.CommentServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.Services.FileServices;
using SocialPhotoEditor.BuisnessLayer.Services.FileServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.Services.LikeServices;
using SocialPhotoEditor.BuisnessLayer.Services.LikeServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.Services.UserServices;
using SocialPhotoEditor.BuisnessLayer.Services.UserServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.ImageViewModels;
using SocialPhotoEditor.DataLayer.DatabaseModels;
using SocialPhotoEditor.DataLayer.Repositories;
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
        private static readonly IRepository<Like> LikeRepository = new LikeRepository();
        private static readonly IEditedRepository<Comment> CommentRepository = new CommentRepository();
        private static readonly IRepository<Subscriber> SubscriberRepository = new SubscriberRepository();
        private static readonly IChangedRepository<UserInfo> UserInfoRepository = new UserInfoRepository();

        private static readonly ICommentService CommentService = new CommentService();
        private static readonly ILikeService LikeService = new LikeService();
        private static readonly IUserService UserService = new UserService();
        private static readonly IFileService FileService = new CloudinaryService();

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

        public IEnumerable<ImageViewModel> GetNews(int pageNumber, string currentUserName)
        {
            var subscriptions = SubscriberRepository.GetAll().Where(x => x.SubscriberName == currentUserName).Select(x => x.UserName);
            var countOnPage = IntSettings.CountNews;
            var images = ImageRepository.GetAll().Where(x => subscriptions.Contains(x.OwnerId)).OrderByDescending(x => x.Time).Skip(countOnPage * pageNumber).Take(countOnPage);
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
            if (currentUserName != ImageRepository.GetFirst(imageFileName).OwnerId) return false;
            if (!ImageRepository.Delete(imageFileName)) return false;
            FileService.RemoveFromStorage(imageFileName);
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

        public string AddImage(string currentUserName, string imageFileName, string folderId, string subscribe)
        {
            var image = new Image
            {
                FileName = imageFileName,
                FolderId = folderId,
                OwnerId = currentUserName
            };
            var imageId = ImageRepository.Add(image);
            if (subscribe == null) return imageId;
            var comment = new Comment {CommentatorId = currentUserName, ImageId = imageId, Text = subscribe};
            CommentRepository.Add(comment);
            return imageId;
        }

        public void CancelAdding(string imageFileName)
        {
            if (ImageRepository.GetAll().FirstOrDefault(x => x.FileName.Contains(imageFileName)) != null) return;
            FileService.RemoveFromStorage(imageFileName);
        }
    }
}
