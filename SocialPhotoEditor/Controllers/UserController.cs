using System.Web.Mvc;

namespace SocialPhotoEditor.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index(string searchString)
        {
            return View();
        }

        public ActionResult Page(string userName)
        {
            return View();
        }

        public ActionResult Setting()
        {
            return View();
        }
    }
}