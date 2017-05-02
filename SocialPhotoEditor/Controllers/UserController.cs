using System.Web.Mvc;

namespace SocialPhotoEditor.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Page(string userName)
        {
            return View();
        }
    }
}