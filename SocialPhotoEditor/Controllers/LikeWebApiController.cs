using System.Web.Http;
using SocialPhotoEditor.BuisnessLayer.Services.LikeServices;
using SocialPhotoEditor.BuisnessLayer.Services.LikeServices.Implementations;

namespace SocialPhotoEditor.Controllers
{
    public class LikeWebApiController : ApiController
    {
        private static readonly ILikeService Service = new LikeService();

        public string Put(string imageFileName)
        {
            return Service.AddLike(User.Identity.Name, imageFileName);
        }

        public bool Delete(string id)
        {
            return Service.DeleteLike(id);
        }
    }
}
