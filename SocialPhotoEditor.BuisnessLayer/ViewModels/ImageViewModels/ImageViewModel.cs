using System;
using System.Collections.Generic;
using SocialPhotoEditor.BuisnessLayer.ViewModels.CommentViewModels;
using SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels;

namespace SocialPhotoEditor.BuisnessLayer.ViewModels.ImageViewModels
{
    public class ImageViewModel
    {
        public UserMinInfoViewModel Owner { get; set; }

        public string FileName { get; set; }

        public DateTime Time { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public int LikesCount { get; set; }

        public string LikeId { get; set; }
    }
}
