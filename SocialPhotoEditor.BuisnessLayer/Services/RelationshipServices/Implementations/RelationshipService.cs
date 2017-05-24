using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.BuisnessLayer.Services.EventServices;
using SocialPhotoEditor.BuisnessLayer.Services.EventServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.Services.UserServices;
using SocialPhotoEditor.BuisnessLayer.Services.UserServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels;
using SocialPhotoEditor.DataLayer.DatabaseModels;
using SocialPhotoEditor.DataLayer.Enums;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.Implementations;

namespace SocialPhotoEditor.BuisnessLayer.Services.RelationshipServices.Implementations
{
    public class RelationshipService : IRelationshipService
    {
        private static readonly IEditedRepository<Subscriber> SubscriberRepository = new SubscriberRepository();

        private static readonly IUserService UserService = new UserService();
        private static readonly IEventService EventService = new EventService();

        public string AddSubscription(string followerName, string userName)
        {
            if (followerName == userName) return null;
            var relationship = new Subscriber { SubscriberName = followerName, UserName = userName };
            var id = SubscriberRepository.Add(relationship);
            if (id != null)
            {
                EventService.AddEvent(followerName, EventEnum.Comment, id, userName);
            }
            return id;
        }

        public bool DeleteSubscription(string id)
        {
            var result = SubscriberRepository.Delete(id);
            if (result)
            {
                EventService.DeleteEvent(EventEnum.Subscription, id);
            }
            return result;
        }

        public IEnumerable<UserRelationshipListViewModel> GetSubscribers(string currentUserName, string userName)
        {
            var subscribers = SubscriberRepository.GetAll().Where(x => x.UserName == userName).Select(x => x.SubscriberName);
            return UserService.GetRelationshipList(currentUserName, subscribers);
        }

        public IEnumerable<UserRelationshipListViewModel> GetSubscriptions(string currentUserName, string userName)
        {
            var subscriptions = SubscriberRepository.GetAll().Where(x => x.SubscriberName == userName).Select(x => x.UserName);
            return UserService.GetRelationshipList(currentUserName, subscriptions);
        }
    }
}
