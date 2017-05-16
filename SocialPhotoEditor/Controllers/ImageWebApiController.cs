using System.Collections.Generic;
using System.Web.Http;
using SocialPhotoEditor.BuisnessLayer.Services.ImageServices;
using SocialPhotoEditor.BuisnessLayer.Services.ImageServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.ImageViewModels;

namespace SocialPhotoEditor.Controllers
{
    public class ImageWebApiController : ApiController
    {
        private static readonly IImageService Service = new ImageService();
        
        public ImageViewModel Post(string imageFileName)
        {
            return Service.GetImage(User.Identity.Name, imageFileName);
        }
        
        public IEnumerable<ImageViewModel> Get()
        {
            return Service.GetNews(User.Identity.Name);
        }
    }
}
