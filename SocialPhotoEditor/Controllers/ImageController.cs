using System.Web.Mvc;

namespace SocialPhotoEditor.Controllers
{
    public class ImageController : Controller
    {
        public ActionResult Index(string imageId)
        {
            return View();
        }

        public ActionResult News()
        {
            return View();
        }
    }
}
