using System;
using System.Collections.Generic;
using SocialPhotoEditor.BuisnessLayer.ViewModels.FolderViewModels;

namespace SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels
{
    public class UserPageViewModel
    {
        public string UserName { get; set; }

        public string Name { get; set; }

        public string AvatarFileName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public DateTime? Birthday { get; set; }

        public string Subscribe { get; set; }

        public IEnumerable<FolderListViewModel> Folders { get; set; }
    }
}