using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.BuisnessLayer.Services.UserServices;
using SocialPhotoEditor.BuisnessLayer.Services.UserServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels;
using SocialPhotoEditor.DataLayer.DatabaseModels;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.Implementations;

namespace SocialPhotoEditor.BuisnessLayer.Services.RelationshipServices.Implementations
{
    public class RelationshipService : IRelationshipService
    {
        private static readonly IEditedRepository<Subscriber> SubscriberRepository = new SubscriberRepository();

        private static readonly IUserService UserService = new UserService();

        public bool CheckSubscription(string userName, string subscriberUserName)
        {
            var relationships = SubscriberRepository.GetAll();
            return relationships.FirstOrDefault(x => x.UserName == userName && x.SubscriberName == subscriberUserName) != null;
        }

        public int GetSubscribersCount(string userName)
        {
            return SubscriberRepository.GetAll().Count(x => x.UserName == userName);
        }

        public int GetSubscriptionsCount(string userName)
        {
            return SubscriberRepository.GetAll().Count(x => x.SubscriberName == userName);
        }

        public void Subscribe(string followerName, string userName)
        {
            var relationship = new Subscriber {SubscriberName = followerName, UserName = userName};
            SubscriberRepository.Add(relationship);
        }

        public void Unsubscribe(string followerName, string userName)
        {
            var relationship = SubscriberRepository.GetAll().FirstOrDefault(x => x.UserName == userName && x.SubscriberName == followerName);
            SubscriberRepository.Delete(relationship);
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
