using System.Web.Mvc;

namespace SocialPhotoEditor.Views
{
    public class UsersController : Controller
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