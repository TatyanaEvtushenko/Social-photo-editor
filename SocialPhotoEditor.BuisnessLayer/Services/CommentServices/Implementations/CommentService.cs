using System;
using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.BuisnessLayer.Services.UserServices;
using SocialPhotoEditor.BuisnessLayer.Services.UserServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.CommentViewModels;
using SocialPhotoEditor.DataLayer.DatabaseModels;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories.Implementations;

namespace SocialPhotoEditor.BuisnessLayer.Services.CommentServices.Implementations
{
    public class CommentService : ICommentService
    {
        private static readonly IChangedRepository<Comment> CommentRepository = new CommentRepository();

        private static readonly IUserService UserService = new UserService();

        public int GetCommentsCount(string imageId)
        {
            return CommentRepository.GetAll().Count(x => x.ImageId == imageId);
        }

        public IEnumerable<CommentViewModel> GetComments(string imageId)
        {
            return
                CommentRepository.GetAll()
                    .Where(x => x.ImageId == imageId)
                    .Select(
                        x =>
                            new CommentViewModel
                            {
                                OwnerUserName = x.CommentatorId,
                                RecipientUserName = x.RecipientId,
                                Text = x.Text,
                                Time = x.Time,
                                AvatarFileName = UserService.GetUserAvatar(x.CommentatorId)
                            });
        }

        public IEnumerable<CommentViewModel> AddComment(string commentatorUserName, string imageId, string text)
        {
            CommentRepository.Add(new Comment
            {
                CommentatorId = commentatorUserName,
                ImageId = imageId,
                Text = text,
                Time = DateTime.Now
            });
            return GetComments(imageId);
        }

        public IEnumerable<CommentViewModel> DeleteComment(string commentatorUserName, string imageId, DateTime time)
        {
            var comment = CommentRepository.GetAll().FirstOrDefault(x => x.CommentatorId == commentatorUserName && x.ImageId == imageId && x.Time == time);
            CommentRepository.Delete(comment);
            return GetComments(imageId);
        }
    }
}
