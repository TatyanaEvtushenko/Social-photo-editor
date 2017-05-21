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

        [HttpPost]
        [Route("api/RelationshipWebApi/Subscribers")]
        public IEnumerable<UserRelationshipListViewModel> GetSubscibers(string userName)
        {
            return Service.GetSubscribers(User.Identity.Name, userName);
        }

        [HttpPost]
        [Route("api/RelationshipWebApi/Subscriptions")]
        public IEnumerable<UserRelationshipListViewModel> GetSubscriptions(string userName)
        {
            return Service.GetSubscriptions(User.Identity.Name, userName);
        }

        [HttpPut]
        public string Subscribe(string userName)
        {
            return Service.AddSubscription(User.Identity.Name, userName);
        }

        [HttpDelete]
        public bool Unsubscribe(string id)
        {
            return Service.DeleteSubscription(id);
        }
    }
}
