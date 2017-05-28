using System.Collections.Generic;
using System.Web.Http;
using SocialPhotoEditor.BuisnessLayer.Services.EventServices;
using SocialPhotoEditor.BuisnessLayer.Services.EventServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.Services.UserServices;
using SocialPhotoEditor.BuisnessLayer.Services.UserServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.EventViewModels;
using SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels;

namespace SocialPhotoEditor.Controllers
{
    public class CurrentUserWebApiController : ApiController
    {
        private static readonly IUserService Service = new UserService();
        private static readonly IEventService EventService = new EventService();
        
        [HttpGet]
        public CurrentUserViewModel GetCurrentUserInfo()
        {
            return Service.GetCurrentUser(User.Identity.Name);
        }

        [HttpGet]
        [Route("api/CurrentUserWebApi/GetEvents")]
        public IEnumerable<EventViewModel> GetEvents()
        {
            return EventService.GetEvents(User.Identity.Name);
        }
    }
}
