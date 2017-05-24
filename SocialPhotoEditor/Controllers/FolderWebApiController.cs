using System.Collections.Generic;
using System.Web.Http;
using SocialPhotoEditor.BuisnessLayer.Services.FolderServices;
using SocialPhotoEditor.BuisnessLayer.Services.FolderServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.FolderViewModels;
using SocialPhotoEditor.BuisnessLayer.ViewModels.ImageViewModels;
using SocialPhotoEditor.Responses;

namespace SocialPhotoEditor.Controllers
{
    public class FolderWebApiController : ApiController
    {
        private static readonly IFolderService Service = new FolderService();

        [HttpPost]
        public FolderViewModel GetFolder(string folderId)
        {
            return Service.GetFolder(folderId);
        }

        [HttpPost]
        public IEnumerable<ImageListViewModel> GetMoreImagesFromFolder(FolderResponse response)
        {
            return Service.GetMoreImagesFromFolder(response.PageNumber, response.FolderId);
        }

        [HttpPost]
        [Route("api/FolderWebApi/MoreUserImages")]
        public IEnumerable<ImageListViewModel> GetMoreUserImages(UserImagesResponse response)
        {
            return Service.GetMoreUserImages(response.PageNumber, response.UserName);
        }

        [HttpPut]
        public string AddFolder(NewFolderResponse response)
        {
            return Service.AddFolder(response.Name, response.Subscribe, User.Identity.Name, response.OwnerUserName);
        }

        [HttpDelete]
        public bool DeleteFolder(string folderId)
        {
            return Service.DeleteFolder(folderId, User.Identity.Name);
        }
    }
}
