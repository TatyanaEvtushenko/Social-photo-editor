using System;
using SocialPhotoEditor.DataLayer.Enums;

namespace SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels
{
    public class UserListViewModel
    {
        public string UserName { get; set; }

        public string AvatarFileName { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public int Age { get; set; }

        public SexEnum Sex { get; set; } = SexEnum.Unknown;

        public bool IsSubscriber { get; set; }

        public DateTime RegisterDate { get; set; }

        public int Popularity { get; set; }
    }
}