using System.Collections.Generic;
using System.Web.Http;
using SocialPhotoEditor.BuisnessLayer.Services.ImageServices;
using SocialPhotoEditor.BuisnessLayer.Services.ImageServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.ImageViewModels;
using SocialPhotoEditor.Responses;

namespace SocialPhotoEditor.Controllers
{
    public class ImageWebApiController : ApiController
    {
        private static readonly IImageService Service = new ImageService();
        
        [HttpPost]
        public ImageViewModel GetImage(string imageFileName)
        {
            return Service.GetImage(User.Identity.Name, imageFileName);
        }
        
        [HttpPost]
        public IEnumerable<ImageViewModel> GetNews(int pageNumber)
        {
            return Service.GetNews(pageNumber, User.Identity.Name);
        }

        [HttpPut]
        public string AddImage(NewImageResponse response)
        {
            return Service.AddImage(User.Identity.Name, response.ImagePath, response.FolderId, response.Subscribe);
        }

        [HttpPost]
        [Route("api/ImageWebApi/CancelAdding")]
        public void CancelAdding(string imageFileName)
        {
            Service.CancelAdding(imageFileName);
        }

        [HttpDelete]
        public bool DeleteImage(string imageFileName)
        {
            return Service.DeleteImage(User.Identity.Name, imageFileName);
        }
    }
}
