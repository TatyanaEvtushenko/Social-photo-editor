using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.BuisnessLayer.Services.FileServices;
using SocialPhotoEditor.BuisnessLayer.Services.FileServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.Services.FolderServices;
using SocialPhotoEditor.BuisnessLayer.Services.FolderServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.Services.LikeServices;
using SocialPhotoEditor.BuisnessLayer.Services.LikeServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels;
using SocialPhotoEditor.DataLayer.DatabaseModels;
using SocialPhotoEditor.DataLayer.Enums;
using SocialPhotoEditor.DataLayer.Repositories;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories.Implementations;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.Implementations;
using SocialPhotoEditor.DataLayer.Repositories.Implementations;
using SociaPhotoEditor.Settings;

namespace SocialPhotoEditor.BuisnessLayer.Services.UserServices.Implementations
{
    public class UserService : IUserService
    {
        private static readonly IChangedRepository<UserInfo> InfoRepository = new UserInfoRepository();
        private static readonly IEditedRepository<Avatar> AvatarRepository = new AvatarRepository();
        private static readonly IRepository<Image> ImageRepository = new ImageRepository();
        private static readonly IRepository<Subscriber> SubscriberRepository = new SubscriberRepository();
        private static readonly IRepository<City> CityRepository = new CityRepository();
        private static readonly IRepository<Event> EventRepository = new EventRepository();

        private static readonly ILikeService LikeService = new LikeService();
        private static readonly IFolderService FolderService = new FolderService();
        private static readonly IFileService FileService = new CloudinaryService();

        private static int GetPopularity(IEnumerable<Image> images)
        {
            if (!images.Any())
                return 0;
            var likesCount = images.Sum(image => LikeService.GetLikesCount(image.FileName));
            return likesCount / images.Count();
        }

        private static IEnumerable<string> GetPopularImages(IEnumerable<Image> images)
        {
            var count = IntSettings.CountPopularImages;
            return images.OrderByDescending(x => LikeService.GetLikesCount(x.FileName)).Take(count).Select(x => x.FileName);
        }

        private static bool CheckSubscription(string userName, string subscriberUserName)
        {
            return SubscriberRepository.GetAll().FirstOrDefault(x => x.UserName == userName && x.SubscriberName == subscriberUserName) != null;
        }

        private static int GetSubscribersCount(string userName)
        {
            return SubscriberRepository.GetAll().Count(x => x.UserName == userName);
        }

        private static int GetSubscriptionsCount(string userName)
        {
            return SubscriberRepository.GetAll().Count(x => x.SubscriberName == userName);
        }

        public void AddUserInfo(string userName)
        {
            var info = new UserInfo {UserName = userName, Sex = SexEnum.Unknown};
            InfoRepository.Add(info);
        }

        public IEnumerable<UserListViewModel> GetUserLists(string currentUserName)
        {
            var infos = InfoRepository.GetAll().Take(IntSettings.CountUserLists);
            return from info in infos
                let userImages = ImageRepository.GetAll().Where(x => x.OwnerId == info.UserName)
                select new UserListViewModel
                {
                    UserName = info.UserName,
                    AvatarFileName = info.AvatarFileName,
                    Name = info.Name,
                    Surname = info.Surname,
                    Location = CityRepository.GetFirst(info.CityId),
                    Birthday = info.Birthday,
                    Sex = info.Sex,
                    RegisterDate = info.RegisterDate,
                    Popularity = GetPopularity(userImages),
                    PopularImages = GetPopularImages(userImages),
                    IsSubscriber = CheckSubscription(info.UserName, currentUserName)
                };
        }

        public CurrentUserViewModel GetCurrentUser(string userName)
        {
            return new CurrentUserViewModel
            {
                User = GetUserMinInfo(userName),
                NewEventsCount = EventRepository.GetAll().Count(x => x.RecipientId == userName && x.IsSeen == false)
            };
        }

        public UserMinInfoViewModel GetUserMinInfo(string userName)
        {
            var info = InfoRepository.GetFirst(userName);
            return new UserMinInfoViewModel
            {
                AvatarFileName = info?.AvatarFileName,
                UserName = userName
            };
        }

        public UserPageViewModel GetUserPage(string userName, string currentUserName)
        {
            var info = InfoRepository.GetFirst(userName);
            return new UserPageViewModel
            {
                UserName = userName,
                AvatarFileName = info?.AvatarFileName,
                AvatarImage = AvatarRepository.GetFirst(info?.AvatarFileName)?.ImageFileName,
                Name = info?.Name,
                Surname = info?.Surname,
                Birthday = info?.Birthday,
                Subscribe = info?.Subscribe,
                Location = CityRepository.GetFirst(info?.CityId),
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
                    AvatarFileName = info?.AvatarFileName,
                    Name = info?.Name,
                    Surname = info?.Surname,
                    UserName = userName,
                    IsSubscriber = CheckSubscription(userName, currentUserName)
                };
        }

        public bool ChangeAvatar(string userName, string imageFileName)
        {
            var info = InfoRepository.GetFirst(userName);
            AvatarRepository.Delete(info?.AvatarFileName);
            var avatar = new Avatar
            {
                ImageFileName = imageFileName,
                AvatarFileName = FileService.GetAvatarUrl(imageFileName)
            };
            var avatarId = AvatarRepository.Add(avatar);
            if (avatarId == null)
                return false;
            info.AvatarFileName = avatarId;
            return InfoRepository.Update(info.UserName, info);
        }
    }
}
