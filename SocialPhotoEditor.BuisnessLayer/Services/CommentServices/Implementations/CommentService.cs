using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.BuisnessLayer.Services.EventServices;
using SocialPhotoEditor.BuisnessLayer.Services.EventServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.CommentViewModels;
using SocialPhotoEditor.DataLayer.DatabaseModels;
using SocialPhotoEditor.DataLayer.Enums;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories.Implementations;

namespace SocialPhotoEditor.BuisnessLayer.Services.CommentServices.Implementations
{
    public class CommentService : ICommentService
    {
        private static readonly IChangedRepository<Comment> CommentRepository = new CommentRepository();

        private static readonly IEventService EventService = new EventService();

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
                Id = x.Id
            });
        }

        public string AddComment(string commentatorUserName, string imageId, string text, string recipientUserName)
        {
            var comment = new Comment
            {
                CommentatorId = commentatorUserName,
                ImageId = imageId,
                Text = text,
                RecipientId = recipientUserName
            };
            var commentId = CommentRepository.Add(comment);
            if (commentId != null)
            {
                EventService.AddEvent(commentatorUserName, EventEnum.Comment, recipientUserName, commentId);
            }
            return commentId;
        }

        public bool DeleteComment(string id)
        {
            var result = CommentRepository.Delete(id);
            if (result)
            {
                EventService.DeleteEvent(EventEnum.Comment, id);
            }
            return result;
        }
    }
}
