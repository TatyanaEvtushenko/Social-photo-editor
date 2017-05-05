using System;
using System.Collections.Generic;
using SocialPhotoEditor.BuisnessLayer.ViewModels.CommentViewModels;

namespace SocialPhotoEditor.BuisnessLayer.ViewModels.ImageViewModels
{
    public class ImageViewModel
    {
        public string FileName { get; set; }

        public DateTime Time { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public int LikesCount { get; set; }
    }
}
