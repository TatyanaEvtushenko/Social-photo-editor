using System.Web.Http;
using SocialPhotoEditor.BuisnessLayer.Services.LikeServices;
using SocialPhotoEditor.BuisnessLayer.Services.LikeServices.Implementations;

namespace SocialPhotoEditor.Controllers
{
    public class LikeWebApiController : ApiController
    {
        private static readonly ILikeService Service = new LikeService();

        public void Put(string imageFileName)
        {
            Service.AddLike(User.Identity.Name, imageFileName);
        }

        public void Delete(string imageFileName)
        {
            Service.DeleteLike(User.Identity.Name, imageFileName);
        }
    }
}
