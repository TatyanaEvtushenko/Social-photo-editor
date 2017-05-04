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
        public UserMinInfoViewModel Get()
        {
            return Service.GetUserMinInfo(User.Identity.Name);
        }
    }
}
