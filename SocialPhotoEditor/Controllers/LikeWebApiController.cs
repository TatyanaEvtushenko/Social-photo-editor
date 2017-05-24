using System.Web.Http;
using SocialPhotoEditor.BuisnessLayer.Services.LikeServices;
using SocialPhotoEditor.BuisnessLayer.Services.LikeServices.Implementations;

namespace SocialPhotoEditor.Controllers
{
    public class LikeWebApiController : ApiController
    {
        private static readonly ILikeService Service = new LikeService();

        [HttpPut]
        public string AddLike(string imageFileName)
        {
            return Service.AddLike(User.Identity.Name, imageFileName);
        }

        [HttpDelete]
        public bool DeleteLike(string id)
        {
            return Service.DeleteLike(id);
        }
    }
}
