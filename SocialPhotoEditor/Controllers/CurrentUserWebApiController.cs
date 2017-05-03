using System.Web.Http;
using SocialPhotoEditor.BuisnessLayer.Services.UserServices;
using SocialPhotoEditor.BuisnessLayer.Services.UserServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels;

namespace SocialPhotoEditor.Controllers
{
    public class CurrentUserWebApiController : ApiController
    {
        private static readonly IUserService Service = new UserService();

        // GET: api/CurrentUserWebApi
        public CurrentUserMinInfoViewModel Get()
        {
            return Service.GetCurrentUserMinInfo(User.Identity.Name);
        }

        //// GET: api/CurrentUserWebApi/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/CurrentUserWebApi
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/CurrentUserWebApi/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/CurrentUserWebApi/5
        //public void Delete(int id)
        //{
        //}
    }
}
