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

        [Route("api/RelationshipWebApi/Subscribers")]
        public IEnumerable<UserRelationshipListViewModel> PostSubscibers(string userName)
        {
            return Service.GetSubscribers(User.Identity.Name, userName);
        }

        [Route("api/RelationshipWebApi/Subscriptions")]
        public IEnumerable<UserRelationshipListViewModel> PostSubscriptions(string userName)
        {
            return Service.GetSubscriptions(User.Identity.Name, userName);
        }

        public void Put(string userName)
        {
            Service.AddSubscription(User.Identity.Name, userName);
        }

        public void Delete(string id)
        {
            Service.DeleteSubscription(id);
        }
    }
}
