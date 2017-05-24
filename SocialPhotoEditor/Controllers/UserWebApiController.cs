using System.Web.Http;
using SocialPhotoEditor.BuisnessLayer.Services.UserServices;
using SocialPhotoEditor.BuisnessLayer.Services.UserServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels;
using SocialPhotoEditor.Responses;

namespace SocialPhotoEditor.Controllers
{
    public class UserWebApiController : ApiController
    {
        private static readonly IUserService Service = new UserService();
        
        [HttpPost]
        public ListViewModel GetUserList(SearchResponse searchResponse)
        {
            return Service.GetUserLists(User.Identity.Name, searchResponse.PageNumber, searchResponse.SearchString, searchResponse.Country, 
                searchResponse.City, searchResponse.MinAge, searchResponse.MaxAge, searchResponse.Sex, searchResponse.SortType);
        }

        [HttpPost]
        public UserPageViewModel GetUserPage(string userName)
        {
            return Service.GetUserPage(userName, User.Identity.Name);
        }

        [HttpPut]
        public bool ChangeAvatar(string imageFileName)
        {
            return Service.ChangeAvatar(User.Identity.Name, imageFileName);
        }

        [HttpGet]
        public UserInfoViewModel GetUserInfo()
        {
            return Service.GetUserInfo(User.Identity.Name);
        }

        [HttpPut]
        public bool UpdateUserInfo(UpdateUserInfoResponse response)
        {
            return Service.UpdateUserInfo(User.Identity.Name, response.AvatarFileName, response.Name, response.Surname,
                response.Birthday, response.Subscribe, response.Country, response.City, response.Sex);
        }
    }
}
