using System.Web.Http;
using SocialPhotoEditor.BuisnessLayer.Services.LikeServices;
using SocialPhotoEditor.BuisnessLayer.Services.LikeServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.LikeViewModels;

namespace SocialPhotoEditor.Controllers
{
    public class LikeWebApiController : ApiController
    {
        private static readonly ILikeService Service = new LikeService();

        public LikeViewModel PostCheckLiked(string imageFileName)
        {
            return Service.GetLike(imageFileName, User.Identity.Name);
        }

        public void PutChangeLike(string imageFileName)
        {
            Service.ChangeLike(imageFileName, User.Identity.Name);
        }
    }
}
