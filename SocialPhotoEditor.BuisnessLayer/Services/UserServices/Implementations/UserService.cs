using System;
using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.BuisnessLayer.Services.CountryServices;
using SocialPhotoEditor.BuisnessLayer.Services.CountryServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.Services.FileServices;
using SocialPhotoEditor.BuisnessLayer.Services.FileServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.Services.FolderServices;
using SocialPhotoEditor.BuisnessLayer.Services.FolderServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.Services.LikeServices;
using SocialPhotoEditor.BuisnessLayer.Services.LikeServices.Implementations;
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
        private static readonly IEditedRepository<Image> ImageRepository = new ImageRepository();
        private static readonly IEditedRepository<Avatar> AvatarRepository = new AvatarRepository();
        private static readonly IEditedRepository<Subscriber> SubscriberRepository = new SubscriberRepository();

        private static readonly ICountryService CountryService = new CountryService();
        private static readonly ILikeService LikeService = new LikeService();
        private static readonly IFolderService FolderService = new FolderService();
        private static readonly IFileService FileService = new CloudinaryService();

        private string GetAvatarFileName(UserInfo info)
        {
            if (info == null || info.AvatarFileName == null)
                return StringSettings.DefaultAvatar;
            return info.AvatarFileName;
        }

        private int GetPopularity(IEnumerable<Image> images)
        {
            if (!images.Any())
                return 0;
            var likesCount = images.Sum(image => LikeService.GetLikesCount(image.FileName));
            return likesCount / images.Count();
        }

        private IEnumerable<string> GetPopularImages(IEnumerable<Image> images)
        {
            var count = IntSettings.CountPopularImages;
            return images.OrderByDescending(x => LikeService.GetLikesCount(x.FileName)).Take(count).Select(x => x.FileName);
        }

        private bool CheckSubscription(string userName, string subscriberUserName)
        {
            var relationships = SubscriberRepository.GetAll();
            return relationships.FirstOrDefault(x => x.UserName == userName && x.SubscriberName == subscriberUserName) != null;
        }

        private int GetSubscribersCount(string userName)
        {
            return SubscriberRepository.GetAll().Count(x => x.UserName == userName);
        }

        private int GetSubscriptionsCount(string userName)
        {
            return SubscriberRepository.GetAll().Count(x => x.SubscriberName == userName);
        }

        private string GetImageFromAvatar(string avatarFileName)
        {
            return AvatarRepository.GetAll().FirstOrDefault(x => x.AvatarFileName == avatarFileName)?.ImageFileName;
        }

        public void AddUserInfo(string userName)
        {
            var info = new UserInfo {UserName = userName, RegisterDate = DateTime.Today.Date};
            InfoRepository.Add(info);
        }

        public IEnumerable<UserListViewModel> GetUserLists(string currentUserName)
        {
            var count = IntSettings.CountUserLists;
            var infos = InfoRepository.Take(count);
            return from info in infos
                let userImages = ImageRepository.GetAll().Where(x => x.OwnerId == info.UserName)
                select new UserListViewModel
                {
                    UserName = info.UserName,
                    AvatarFileName = GetAvatarFileName(info),
                    Name = info.Name,
                    Surname = info.Surname,
                    Location = CountryService.GetLocation(info.CityId),
                    Birthday = info.Birthday,
                    Sex = info.Sex,
                    RegisterDate = info.RegisterDate,
                    Popularity = GetPopularity(userImages),
                    PopularImages = GetPopularImages(userImages),
                    IsSubscriber = CheckSubscription(info.UserName, currentUserName)
                };
        }

        public UserMinInfoViewModel GetUserMinInfo(string userName)
        {
            var info = InfoRepository.GetAll().FirstOrDefault(x => x.UserName == userName);
            return new UserMinInfoViewModel
            {
                AvatarFileName = GetAvatarFileName(info),
                UserName = userName
            };
        }

        public UserPageViewModel GetUserPage(string userName, string currentUserName)
        {
            var info = InfoRepository.GetAll().FirstOrDefault(x => x.UserName == userName);
            return new UserPageViewModel
            {
                UserName = userName,
                AvatarFileName = GetAvatarFileName(info),
                AvatarImage = GetImageFromAvatar(info?.AvatarFileName),
                Name = info?.Name,
                Surname = info?.Surname,
                Birthday = info?.Birthday,
                Subscribe = info?.Subscribe,
                Location = CountryService.GetLocation(info.CityId),
                Folders = FolderService.GetFolderLists(userName),
                SubscribersCount = GetSubscribersCount(userName),
                SubscriptionsCount = GetSubscriptionsCount(userName),
                IsSubscriber = CheckSubscription(userName, currentUserName),
            };
        }

        public IEnumerable<UserRelationshipListViewModel> GetRelationshipList(string currentUserName, IEnumerable<string> userNames)
        {
            var infos = InfoRepository.GetAll();
            return from userName in userNames
                let info = infos.FirstOrDefault(x => x.UserName == userName)
                select new UserRelationshipListViewModel
                {
                    AvatarFileName = GetAvatarFileName(info),
                    Name = info?.Name,
                    Surname = info?.Surname,
                    UserName = userName,
                    IsSubscriber = CheckSubscription(userName, currentUserName)
                };
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
    }
}
