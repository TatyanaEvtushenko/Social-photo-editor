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

        // POST
        public IEnumerable<ImageListViewModel> Post(string userName, string folderName)
        {
            return Service.GetImageLists(userName, folderName);
        }
    }
}
