using System.Collections.Generic;
using SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels;

namespace SocialPhotoEditor.BuisnessLayer.Services.UserServices
{
    public interface IUserService
    {
        CurrentUserViewModel GetCurrentUser(string userName);

        void AddUserInfo(string userName);

        IEnumerable<UserListViewModel> GetUserLists(string currentUserName);

        UserMinInfoViewModel GetUserMinInfo(string userName);

        UserPageViewModel GetUserPage(string userName, string currentUserName);

        bool ChangeAvatar(string userName, string imageFileName);

        IEnumerable<UserRelationshipListViewModel> GetRelationshipList(string currentUserName, IEnumerable<string> userNames);
    }
}
