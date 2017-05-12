using System;
using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.BuisnessLayer.Services.CountryServices;
using SocialPhotoEditor.BuisnessLayer.Services.CountryServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.Services.FileServices;
using SocialPhotoEditor.BuisnessLayer.Services.FileServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.Services.FolderServices;
using SocialPhotoEditor.BuisnessLayer.Services.FolderServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.Services.ImageServices;
using SocialPhotoEditor.BuisnessLayer.Services.ImageServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.Services.RelationshipServices;
using SocialPhotoEditor.BuisnessLayer.Services.RelationshipServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels;
using SocialPhotoEditor.DataLayer.DatabaseModels;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories.Implementations;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.Implementations;
using SociaPhotoEditor.Settings;

namespace SocialPhotoEditor.BuisnessLayer.Services.UserServices.Implementations
{
    public class UserService : IUserService
    {
        private static readonly IChangedRepository<UserInfo> InfoRepository = new UserInfoRepository();
        private static readonly IEditedRepository<Avatar> AvatarRepository = new AvatarRepository();

        private static readonly ICountryService CountryService = new CountryService();
        private static readonly IImageService ImageService = new ImageService();
        private static readonly IRelationshipService RelationshipService = new RelationshipService();
        private static readonly IFolderService FolderService = new FolderService();
        private static readonly IFileService FileService = new CloudinaryService();

        private readonly string defaultAvatarFileName = StringSettings.DefaultAvatar;

        private static int GetAge(UserInfo info)
        {
            if (info.Birthday == null)
                return 0;
            var birthday = info.Birthday.Value;
            var yearSubtract = DateTime.Today.Year - birthday.Year;
            if (DateTime.Today.Month < birthday.Month ||
                DateTime.Today.Month == birthday.Month && DateTime.Today.Day < birthday.Day)
                return yearSubtract - 1;
            return yearSubtract;
        }

        private static string GetFullTrueName(UserInfo info)
        {
            return $"{info.Name} {info.Surname}";
        }

        private string GetAvatarFileName(UserInfo info)
        {
            return info.AvatarFileName ?? defaultAvatarFileName;
        }

        private static string GetLocation(UserInfo info)
        {
            var location = CountryService.GetLocation(info.CityId);
            return location.CountryName == null ? location.CityName : $"{location.CountryName}, {location.CityName}";
        }

        public void AddUserInfo(string userName)
        {
            var info = new UserInfo {UserName = userName, RegisterDate = DateTime.Today.Date};
            InfoRepository.Add(info);
        }

        public IEnumerable<UserListViewModel> GetUserLists(string currentUserName, int count)
        {
            var infos = InfoRepository.Take(count);
            return from info in infos
                let location = CountryService.GetLocation(info.CityId)
                select new UserListViewModel
                {
                    UserName = info.UserName,
                    AvatarFileName = GetAvatarFileName(info),
                    Name = GetFullTrueName(info),
                    Country = location.CountryName,
                    City = location.CityName,
                    Age = GetAge(info),
                    Sex = info.Sex,
                    RegisterDate = info.RegisterDate,
                    Popularity = ImageService.GetPopularity(info.UserName),
                    IsSubscriber = RelationshipService.CheckSubscription(info.UserName, currentUserName)
                };
        }

        public UserMinInfoViewModel GetUserMinInfo(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return null;
            var info = InfoRepository.GetAll().FirstOrDefault(x => x.UserName == userName);
            return new UserMinInfoViewModel
            {
                AvatarFileName = GetAvatarFileName(info),
                Name = userName
            };
        }

        public UserPageViewModel GetUserPage(string userName, string currentUserName)
        {
            var info = InfoRepository.GetAll().FirstOrDefault(x => x.UserName == userName);
            if (info == null)
                return null;
            return new UserPageViewModel
            {
                UserName = info.UserName,
                AvatarFileName = GetAvatarFileName(info),
                Name = GetFullTrueName(info),
                Birthday = info.Birthday,
                Subscribe = info.Subscribe,
                Location = GetLocation(info),
                Folders = FolderService.GetFolderLists(userName),
                SubscribersCount = RelationshipService.GetSubscribersCount(userName),
                SubscriptionsCount = RelationshipService.GetSubscriptionsCount(userName),
                IsSubscriber = RelationshipService.CheckSubscription(userName, currentUserName),
            };
        }

        public string GetUserAvatar(string userName)
        {
            var info = InfoRepository.GetAll().FirstOrDefault(x => x.UserName == userName);
            return GetAvatarFileName(info);
        }

        public void ChangeAvatar(string userName, string imageFileName)
        {
            var info = InfoRepository.GetAll().FirstOrDefault(x => x.UserName == userName);
            AvatarRepository.Delete(new Avatar {AvatarFileName = info.AvatarFileName});
            var avatar = new Avatar
            {
                ImageFileName = imageFileName,
                AvatarFileName = FileService.GetAvatarUrl(imageFileName)
            };
            AvatarRepository.Add(avatar);
            info.AvatarFileName = avatar.AvatarFileName;
            InfoRepository.Update(info);
        }

        public IEnumerable<UserRelationshipListViewModel> GetRelationshipList(string currentUserName, IEnumerable<string> userNames)
        {
            var infos = InfoRepository.GetAll();
            return from userName in userNames
                let info = infos.FirstOrDefault(x => x.UserName == userName)
                select
                    new UserRelationshipListViewModel
                    {
                        AvatarFileName = GetAvatarFileName(info),
                        Name = GetFullTrueName(info),
                        UserName = userName,
                        IsSubscriber = RelationshipService.CheckSubscription(userName, currentUserName)
                    };
        }
    }
}
