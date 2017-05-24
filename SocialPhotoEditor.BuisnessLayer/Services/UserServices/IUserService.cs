using System;
using System.Collections.Generic;
using SocialPhotoEditor.BuisnessLayer.Enums;
using SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels;
using SocialPhotoEditor.DataLayer.Enums;

namespace SocialPhotoEditor.BuisnessLayer.Services.UserServices
{
    public interface IUserService
    {
        CurrentUserViewModel GetCurrentUser(string userName);

        void AddUserInfo(string userName);

        ListViewModel GetUserLists(string currentUserName, int pageNumber, string searchString, string country, string city, 
            int minAge, int maxAge, SexEnum sex, SortEnum sortType);

        UserMinInfoViewModel GetUserMinInfo(string userName);

        UserPageViewModel GetUserPage(string userName, string currentUserName);

        bool ChangeAvatar(string currentUserName, string imageFileName);

        IEnumerable<UserRelationshipListViewModel> GetRelationshipList(string currentUserName, IEnumerable<string> userNames);

        UserInfoViewModel GetUserInfo(string currentUserName);

        bool UpdateUserInfo(string currentUserName, string avatarFileName, string name, string surname, DateTime birthday, string subscribe,
            string country, string city, SexEnum sex);
    }
}
