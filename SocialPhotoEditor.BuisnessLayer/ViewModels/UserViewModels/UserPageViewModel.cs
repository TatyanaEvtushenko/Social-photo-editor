﻿using System;
using System.Collections.Generic;
using SocialPhotoEditor.BuisnessLayer.ViewModels.FolderViewModels;

namespace SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels
{
    public class UserPageViewModel
    {
        public string UserName { get; set; }

        public string Name { get; set; }

        public string AvatarFileName { get; set; }

        public string Location { get; set; }

        public DateTime? Birthday { get; set; }

        public string Subscribe { get; set; }

        public int SubscribersCount { get; set; }

        public int SubscriptionsCount { get; set; }

        public bool IsSubscriber { get; set; }

        public IEnumerable<FolderListViewModel> Folders { get; set; }
    }
}