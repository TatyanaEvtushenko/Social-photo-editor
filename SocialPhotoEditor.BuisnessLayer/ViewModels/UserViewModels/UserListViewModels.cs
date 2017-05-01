using SocialPhotoEditor.DataLayer.Enums;

namespace SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels
{
    public class UserListViewModels
    {
        public string UserName { get; set; }
        public string AvatarFileName { get; set; }
        public string Name { get; set; }
        public string Land { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public SexEnum Sex { get; set; } = SexEnum.Unknown;
        public bool IsSubscriber { get; set; }
    }
}