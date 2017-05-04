namespace SocialPhotoEditor.BuisnessLayer.Services.RelationshipServices
{
    public interface IRelationshipService
    {
        bool CheckSubscription(string userName, string subscriberUserName);

        int GetSubscribersCount(string userName);

        int GetSubscriptionsCount(string userName);
    }
}
