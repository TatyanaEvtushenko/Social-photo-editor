using System.Web.Http;
using SocialPhotoEditor.BuisnessLayer.Services.FolderServices;
using SocialPhotoEditor.BuisnessLayer.Services.FolderServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.FolderViewModels;

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
    }
}
