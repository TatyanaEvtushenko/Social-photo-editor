using System;
using System.Collections.Generic;
using SocialPhotoEditor.DataLayer.DatabaseModels;
using SocialPhotoEditor.DataLayer.Enums;

namespace SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels
{
    public class UserListViewModel
    {
        public string UserName { get; set; }

        public string AvatarFileName { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public City Location { get; set; }

        public DateTime? Birthday { get; set; }

        public SexEnum Sex { get; set; } = SexEnum.Unknown;

        public string SubscriptionId { get; set; }

        public DateTime RegisterDate { get; set; }

        public int Popularity { get; set; }

        public IEnumerable<string> PopularImages { get; set; }
    }
}