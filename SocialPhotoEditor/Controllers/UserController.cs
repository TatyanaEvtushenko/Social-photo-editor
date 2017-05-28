using System.Web.Mvc;

namespace SocialPhotoEditor.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Index(string searchString)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Page(string userName)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Setting()
        {
            return View();
        }
    }
}