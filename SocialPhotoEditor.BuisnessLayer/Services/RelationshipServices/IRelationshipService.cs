using System.Collections.Generic;
using SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels;

namespace SocialPhotoEditor.BuisnessLayer.Services.RelationshipServices
{
    public interface IRelationshipService
    {
        bool CheckSubscription(string userName, string subscriberUserName);

        int GetSubscribersCount(string userName);

        int GetSubscriptionsCount(string userName);

        void Subscribe(string followerName, string userName);

        void Unsubscribe(string followerName, string userName);

        IEnumerable<UserMinInfoViewModel> GetSubscribers(string userName);

        IEnumerable<UserMinInfoViewModel> GetSubscriptions(string userName);
    }
}
