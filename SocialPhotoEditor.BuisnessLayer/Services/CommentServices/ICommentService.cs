using System;
using System.Collections.Generic;
using SocialPhotoEditor.BuisnessLayer.ViewModels.CommentViewModels;

namespace SocialPhotoEditor.BuisnessLayer.Services.CommentServices
{
    public interface ICommentService
    {
        int GetCommentsCount(string imageId);

        IEnumerable<CommentViewModel> GetComments(string imageId);

        void AddComment(string commentatorUserName, string imageId, string text, DateTime time, string recipientUserName);

        void DeleteComment(string commentatorUserName, string imageId, DateTime time);
    }
}
