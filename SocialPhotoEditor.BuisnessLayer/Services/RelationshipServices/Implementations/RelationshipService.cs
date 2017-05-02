using System.Linq;
using SocialPhotoEditor.DataLayer.DatabaseModels;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.Implementations;

namespace SocialPhotoEditor.BuisnessLayer.Services.RelationshipServices.Implementations
{
    public class RelationshipService : IRelationshipService
    {
        private static readonly IEditedRepository<Subscriber> SubscriberRepository = new SubscriberRepository();

        public bool CheckSubscription(string userName, string subscriberUserName)
        {
            var relationships = SubscriberRepository.GetAll();
            return relationships.FirstOrDefault(x => x.UserName == userName && x.SubscriberName == subscriberUserName) != null;
        }
    }
}
