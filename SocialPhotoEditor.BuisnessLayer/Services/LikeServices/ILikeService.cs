namespace SocialPhotoEditor.BuisnessLayer.Services.LikeServices
{
    public interface ILikeService
    {
        int GetLikesCount(string imageId);

        string AddLike(string currentUserName, string imageId);

        bool DeleteLike(string id);
    }
}
