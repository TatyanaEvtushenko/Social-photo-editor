using System.Collections.Generic;
using SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels;

namespace SocialPhotoEditor.BuisnessLayer.Services.UserServices
{
    public interface IUserService
    {
        void AddUserInfo(string userName);

        IEnumerable<UserListViewModel> GetUserLists(string currentUserName, int count);

        CurrentUserMinInfoViewModel GetCurrentUserMinInfo(string currentUserName);

        UserPageViewModel GetUserPage(string userName, string currentUserName);
    }
}
