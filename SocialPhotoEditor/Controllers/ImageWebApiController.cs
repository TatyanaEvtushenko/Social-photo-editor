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

        private readonly int MaxImagesCountOnPage = 21;

        // POST
        public IEnumerable<ImageListViewModel> Post(string folderId)
        {
            return Service.GetImageLists(folderId, MaxImagesCountOnPage);
        }
    }
}
