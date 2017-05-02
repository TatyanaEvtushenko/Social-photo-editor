﻿using System.Collections.Generic;
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

        //GET
        public IEnumerable<UserListViewModel> Get()
        {
            var result = Service.GetUserLists(User.Identity.Name, MaxCountUsersOnPage);
            return result;
        }

        //// POST: api/Test

        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Test/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Test/5
        //public void Delete(int id)
        //{
        //}
    }
}
