using System.Collections.Generic;
using System.Web.Http;
using SocialPhotoEditor.BuisnessLayer.Services.UserServices;
using SocialPhotoEditor.BuisnessLayer.Services.UserServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels;

namespace SocialPhotoEditor.Controllers
{
    public class UserWebApiController : ApiController
    {
        private static readonly IUserService Service = new UserService();
        private static readonly int MaxCountUsersOnPage = 20;
        
        public IEnumerable<UserListViewModel> Get()
        {
            return Service.GetUserLists(User.Identity.Name, MaxCountUsersOnPage); ;
        }
        
        public UserPageViewModel Post(string userName)
        {
            return Service.GetUserPage(userName, User.Identity.Name);
        }
    }
}
