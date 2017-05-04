using System.Collections.Generic;
using SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels;

namespace SocialPhotoEditor.BuisnessLayer.Services.UserServices
{
    public interface IUserService
    {
        void AddUserInfo(string userName);

        IEnumerable<UserListViewModel> GetUserLists(string currentUserName, int count);

        UserMinInfoViewModel GetUserMinInfo(string userName);

        UserPageViewModel GetUserPage(string userName, string currentUserName);
    }
}
