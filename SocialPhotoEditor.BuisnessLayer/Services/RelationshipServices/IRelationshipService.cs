namespace SocialPhotoEditor.BuisnessLayer.Services.RelationshipServices
{
    public interface IRelationshipService
    {
        bool CheckSubscription(string userName, string subscriberUserName);
    }
}
