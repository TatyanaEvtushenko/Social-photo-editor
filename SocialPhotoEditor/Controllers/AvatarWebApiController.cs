using System.Web.Http;
using SocialPhotoEditor.BuisnessLayer.Services.UserServices;
using SocialPhotoEditor.BuisnessLayer.Services.UserServices.Implementations;

namespace SocialPhotoEditor.Controllers
{
    public class AvatarWebApiController : ApiController
    {
        private static readonly IUserService Service = new UserService();

        public void Put(string imageFileName)
        {
            Service.ChangeAvatar(User.Identity.Name, imageFileName);
        }
    }
}
