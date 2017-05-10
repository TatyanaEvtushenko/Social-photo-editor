using SocialPhotoEditor.BuisnessLayer.ViewModels.LikeViewModels;

namespace SocialPhotoEditor.BuisnessLayer.Services.LikeServices
{
    public interface ILikeService
    {
        int GetLikesCount(string imageId);

        void ChangeLike(string imageId, string userName);

        LikeViewModel GetLike(string imageId, string userName);
    }
}
