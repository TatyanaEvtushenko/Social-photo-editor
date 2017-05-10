using System.Web.Mvc;

namespace SocialPhotoEditor.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Index(string imageId)
        {
            return View();
        }
    }
}
