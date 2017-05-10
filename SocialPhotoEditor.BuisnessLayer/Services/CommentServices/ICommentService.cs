using System;
using System.Collections.Generic;
using SocialPhotoEditor.BuisnessLayer.ViewModels.CommentViewModels;

namespace SocialPhotoEditor.BuisnessLayer.Services.CommentServices
{
    public interface ICommentService
    {
        int GetCommentsCount(string imageId);

        IEnumerable<CommentViewModel> GetComments(string imageId);

        IEnumerable<CommentViewModel> AddComment(string commentatorUserName, string imageId, string text);

        IEnumerable<CommentViewModel> DeleteComment(string commentatorUserName, string imageId, DateTime time);
    }
}
