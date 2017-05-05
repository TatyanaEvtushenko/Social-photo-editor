﻿using System.Collections.Generic;
using SocialPhotoEditor.BuisnessLayer.ViewModels.CommentViewModels;

namespace SocialPhotoEditor.BuisnessLayer.Services.CommentServices
{
    public interface ICommentService
    {
        int GetCommentsCount(string imageId);

        IEnumerable<CommentViewModel> GetComments(string imageId);
    }
}
