﻿using System;
using System.Collections.Generic;
using SocialPhotoEditor.BuisnessLayer.ViewModels.FolderViewModels;
using SocialPhotoEditor.BuisnessLayer.ViewModels.ImageViewModels;
using SocialPhotoEditor.DataLayer.DatabaseModels;

namespace SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels
{
    public class UserPageViewModel
    {
        public string UserName { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string AvatarFileName { get; set; }

        public City Location { get; set; }

        public DateTime? Birthday { get; set; }

        public string Subscribe { get; set; }

        public int SubscribersCount { get; set; }

        public int SubscriptionsCount { get; set; }

        public string SubscriptionId { get; set; }

        public IEnumerable<FolderListViewModel> Folders { get; set; }

        public int ImagesCount { get; set; }

        public IEnumerable<ImageListViewModel> UserImages { get; set; }
    }
}