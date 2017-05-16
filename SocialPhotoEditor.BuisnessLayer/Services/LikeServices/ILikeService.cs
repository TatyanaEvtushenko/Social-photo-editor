namespace SocialPhotoEditor.BuisnessLayer.Services.LikeServices
{
    public interface ILikeService
    {
        int GetLikesCount(string imageId);

        void AddLike(string currentUserName, string imageId);

        void DeleteLike(string currentUserName, string imageId);
    }
}
