using System;
using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.BuisnessLayer.ViewModels.CommentViewModels;
using SocialPhotoEditor.DataLayer.DatabaseModels;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories.Implementations;

namespace SocialPhotoEditor.BuisnessLayer.Services.CommentServices.Implementations
{
    public class CommentService : ICommentService
    {
        private static readonly IChangedRepository<Comment> CommentRepository = new CommentRepository();

        public int GetCommentsCount(string imageId)
        {
            return CommentRepository.GetAll().Count(x => x.ImageId == imageId);
        }

        public IEnumerable<CommentViewModel> GetComments(string imageId)
        {
            var imagesComments = CommentRepository.GetAll().Where(x => x.ImageId == imageId);
            return imagesComments.Select(x => new CommentViewModel
            {
                OwnerUserName = x.CommentatorId,
                RecipientUserName = x.RecipientId,
                Text = x.Text,
                Time = x.Time,
            });
        }

        public void AddComment(string commentatorUserName, string imageId, string text, DateTime time, string recipientUserName)
        {
            var comment = new Comment
            {
                CommentatorId = commentatorUserName,
                ImageId = imageId,
                Text = text,
                Time = time,
                RecipientId = recipientUserName
            };
            CommentRepository.Add(comment);
        }

        public void DeleteComment(string commentatorUserName, string imageId, DateTime time)
        {
            var comment = new Comment {CommentatorId = commentatorUserName, Time = time, ImageId = imageId};
            CommentRepository.Delete(comment);
        }
    }
}
