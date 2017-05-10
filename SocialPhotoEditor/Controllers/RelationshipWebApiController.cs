using System.Collections.Generic;
using System.Web.Http;
using SocialPhotoEditor.BuisnessLayer.Services.RelationshipServices;
using SocialPhotoEditor.BuisnessLayer.Services.RelationshipServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels;

namespace SocialPhotoEditor.Controllers
{
    public class RelationshipWebApiController : ApiController
    {
        private static readonly IRelationshipService Service =  new RelationshipService();

        public IEnumerable<UserMinInfoViewModel> Post(string userName)
        {
            return Service.GetSubscribers(userName);
        }

        public void Put(string userName)
        {
            Service.Subscribe(User.Identity.Name, userName);
        }

        public void Delete(string userName)
        {
            Service.Unsubscribe(User.Identity.Name, userName);
        }
    }
}
