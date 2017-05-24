using System;
using SocialPhotoEditor.DataLayer.Enums;

namespace SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels
{
    public class UserInfoViewModel
    {
        public string UserName { get; set; }
        
        public DateTime RegisterDate { get; set; }

        public string AvatarFileName { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime? Birthday { get; set; }

        public string CityName { get; set; }

        public string CountryName { get; set; }

        public string Subscribe { get; set; }

        public SexEnum Sex { get; set; }
    }
}
