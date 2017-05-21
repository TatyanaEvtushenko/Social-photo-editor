using System;
using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.BuisnessLayer.Enums;
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

        private static string GetSubscriptionId(string userName, string subscriberUserName)
        {
            return SubscriberRepository.GetAll().FirstOrDefault(x => x.UserName == userName && x.SubscriberName == subscriberUserName)?.Id;
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

        private static void GetSearchStringInfos(ref List<UserInfo> infos, string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                infos = infos.Where(x => x.UserName.Contains(searchString) || (x.Name + " " + x.Surname).Contains(searchString) ||
                            (x.Surname + " " + x.Name).Contains(searchString)).ToList();
            }
        }

        private static void GetLocationInfos(ref List<UserInfo> infos, string country, string city)
        {
            var cities = CityRepository.GetAll();
            if (!string.IsNullOrEmpty(city))
            {
                var cityId = cities.FirstOrDefault(x => x.CountryName == country && x.CityName == city)?.Id;
                infos = infos.Where(x => x.CityId == cityId).ToList();
            }
            else
            {
                if (string.IsNullOrEmpty(country)) return;
                var cityIds = cities.Where(x => x.CountryName == country).Select(x => x.Id);
                infos = infos.Where(x => cityIds.Contains(x.CityId)).ToList();
            }
        }

        private static void GetAgeInfos(ref List<UserInfo> infos, int minAge, int maxAge)
        {
            var today = DateTime.Now;
            if (minAge >= 0)
            {
                var maxDate = DateTime.Parse($"{today.Day}.{today.Month}.{today.Year - minAge}");
                infos = infos.Where(x => x.Birthday != null && x.Birthday.Value <= maxDate).ToList();
            }
            if (maxAge < 0) return;
            var minDate = DateTime.Parse($"{today.Day}.{today.Month}.{today.Year - maxAge}");
            infos = infos.Where(x => x.Birthday != null && x.Birthday.Value >= minDate).ToList();
        }

        private static void GetSexInfos(ref List<UserInfo> infos, SexEnum sex)
        {
            if (sex != SexEnum.Unknown)
            {
                infos = infos.Where(x => x.Sex == sex).ToList();
            }
        }

        private static List<UserInfo> GetFilterInfos(string searchString, string country, string city,
            int minAge, int maxAge, SexEnum sex)
        {
            var infos = InfoRepository.GetAll();
            GetSearchStringInfos(ref infos, searchString);
            GetLocationInfos(ref infos, country, city);
            GetAgeInfos(ref infos, minAge, maxAge);
            GetSexInfos(ref infos, sex);
            return infos;
        }

        private static void SortInfos(ref List<UserInfo> infos, SortEnum sort)
        {
            switch (sort)
            {
                case SortEnum.Popularity:
                    var images = ImageRepository.GetAll();
                    infos.Sort(
                        (info, userInfo) =>
                            GetPopularity(images.Where(x => x.OwnerId == info.UserName)) <
                            GetPopularity(images.Where(x => x.OwnerId == userInfo.UserName))
                                ? 1
                                : -1);
                    return;
                case SortEnum.RegisterData:
                    infos.Sort((info, userInfo) => info.RegisterDate < userInfo.RegisterDate ? 1 : -1);
                    return;
                default:
                    throw new ArgumentOutOfRangeException(nameof(sort), sort, null);
            }
        }

        public ListViewModel GetUserLists(string currentUserName, int pageNumber, string searchString, string country, string city, int minAge, int maxAge, SexEnum sex, SortEnum sortType)
        {
            var infos = GetFilterInfos(searchString, country, city, minAge, maxAge, sex);
            SortInfos(ref infos, sortType);
            var countOnPage = IntSettings.CountUserLists;
            return new ListViewModel
            {
                UsersCount = infos.Count,
                Users = from info in infos.Skip(countOnPage*pageNumber).Take(countOnPage)
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
                        SubscriptionId = GetSubscriptionId(info.UserName, currentUserName)
                    }
            };
        }

        public CurrentUserViewModel GetCurrentUser(string userName)
        {
            return new CurrentUserViewModel
            {
                User = GetUserMinInfo(userName), NewEventsCount = EventRepository.GetAll().Count(x => x.RecipientId == userName && x.IsSeen == false)
            };
        }

        public UserMinInfoViewModel GetUserMinInfo(string userName)
        {
            var info = InfoRepository.GetFirst(userName);
            return new UserMinInfoViewModel
            {
                AvatarFileName = info?.AvatarFileName, UserName = userName
            };
        }

        public UserPageViewModel GetUserPage(string userName, string currentUserName)
        {
            var info = InfoRepository.GetFirst(userName);
            return new UserPageViewModel
            {
                UserName = userName, AvatarFileName = info?.AvatarFileName, AvatarImage = AvatarRepository.GetFirst(info?.AvatarFileName)?.ImageFileName, Name = info?.Name, Surname = info?.Surname, Birthday = info?.Birthday, Subscribe = info?.Subscribe, Location = CityRepository.GetFirst(info?.CityId), Folders = FolderService.GetFolderLists(userName), SubscribersCount = GetSubscribersCount(userName), SubscriptionsCount = GetSubscriptionsCount(userName), SubscriptionId = GetSubscriptionId(userName, currentUserName),
            };
        }

        public IEnumerable<UserRelationshipListViewModel> GetRelationshipList(string currentUserName, IEnumerable<string> userNames)
        {
            var infos = InfoRepository.GetAll();
            return from userName in userNames
                let info = infos.FirstOrDefault(x => x.UserName == userName)
                select new UserRelationshipListViewModel
                {
                    AvatarFileName = info?.AvatarFileName, Name = info?.Name, Surname = info?.Surname, UserName = userName, SubscriptionId = GetSubscriptionId(userName, currentUserName)
                };
        }

        public bool ChangeAvatar(string userName, string imageFileName)
        {
            var info = InfoRepository.GetFirst(userName);
            AvatarRepository.Delete(info?.AvatarFileName);
            var avatar = new Avatar
            {
                ImageFileName = imageFileName, AvatarFileName = FileService.GetAvatarUrl(imageFileName)
            };
            var avatarId = AvatarRepository.Add(avatar);
            if (avatarId == null)
                return false;
            info.AvatarFileName = avatarId;
            return InfoRepository.Update(info.UserName, info);
        }
    }
}
