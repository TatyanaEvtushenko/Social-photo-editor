using System.Collections.Generic;
using System.Web;
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
        public void AddImage(NewImageResponse response)
        {
            Service.AddImage(User.Identity.Name, response.ImagePath, response.FolderId, response.Subscribe);
            var url = HttpContext.Current.Request.ServerVariables["SERVER_NAME"] + "/User/Page/?userName=" +
                      User.Identity.Name;
            Redirect(url);
        }

        [HttpDelete]
        public bool DeleteImage(string imageFileName)
        {
            return Service.DeleteImage(User.Identity.Name, imageFileName);
        }
    }
}
