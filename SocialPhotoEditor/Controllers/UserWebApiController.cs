﻿using System.Web.Http;
using SocialPhotoEditor.BuisnessLayer.Services.UserServices;
using SocialPhotoEditor.BuisnessLayer.Services.UserServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels;
using SocialPhotoEditor.Responses;

namespace SocialPhotoEditor.Controllers
{
    public class UserWebApiController : ApiController
    {
        private static readonly IUserService Service = new UserService();

  //      [Route("localhost:57382/api/UserWebApi")]
        //public ListViewModel GetUserList(int pageNumber, string searchString, string country, string city,
        //    int minAge, int maxAge, SexEnum sex, SortEnum sortType)
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
    }
}
