using System;
using System.Collections.Generic;
using SocialPhotoEditor.BuisnessLayer.ViewModels.PhotoViewModels;

namespace SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels
{
    public class UserPageViewModels
    {
        public string UserName { get; set; }
        public string AvatarFileName { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public DateTime? Birthday { get; set; }
        public List<FolderViewModels> Folders { get; set; }
    }
}