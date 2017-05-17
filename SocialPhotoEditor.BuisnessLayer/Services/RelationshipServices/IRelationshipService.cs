using System.Collections.Generic;
using SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels;

namespace SocialPhotoEditor.BuisnessLayer.Services.RelationshipServices
{
    public interface IRelationshipService
    {
        void Subscribe(string followerName, string userName);

        void Unsubscribe(string followerName, string userName);

        IEnumerable<UserRelationshipListViewModel> GetSubscribers(string currentUserName, string userName);

        IEnumerable<UserRelationshipListViewModel> GetSubscriptions(string currentUserName, string userName);
    }
}
