using System.Collections.Generic;
using SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels;

namespace SocialPhotoEditor.BuisnessLayer.Services.RelationshipServices
{
    public interface IRelationshipService
    {
        string AddSubscription(string followerName, string userName);

        bool DeleteSubscription(string id);

        IEnumerable<UserRelationshipListViewModel> GetSubscribers(string currentUserName, string userName);

        IEnumerable<UserRelationshipListViewModel> GetSubscriptions(string currentUserName, string userName);
    }
}
