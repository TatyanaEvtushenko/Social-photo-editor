using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SocialPhotoEditor.BuisnessLayer.Services.FileServices;
using SocialPhotoEditor.BuisnessLayer.Services.FileServices.Implementations;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace SocialPhotoEditor.Controllers
{
    [Authorize]
    public class ImageController : Controller
    {
        private static readonly IFileService FileService = new CloudinaryService();

        [HttpGet]
        public ActionResult News()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(HttpPostedFileBase file)
        {
            if (file == null) return HttpNotFound();
            ViewData["ImageName"] = file.FileName;
            var localPath = Server.MapPath("~/TempFiles/" + Path.GetFileName(file.FileName));
            file.SaveAs(localPath);
            ViewData["ImagePath"] = await FileService.DownloadToStorage(localPath);
            return View();
        }
    }
}
