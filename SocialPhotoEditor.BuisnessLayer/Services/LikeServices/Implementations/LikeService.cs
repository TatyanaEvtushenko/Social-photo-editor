using System.Linq;
using SocialPhotoEditor.DataLayer.DatabaseModels;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.Implementations;

namespace SocialPhotoEditor.BuisnessLayer.Services.LikeServices.Implementations
{
    public class LikeService : ILikeService
    {
        private static readonly IEditedRepository<Like> LikeRepository = new LikeRepository();

        public void AddLike(string currentUserName, string imageId)
        {
            var like = new Like { ImageId = imageId, OwnerId = currentUserName };
            LikeRepository.Add(like);
        }

        public void DeleteLike(string currentUserName, string imageId)
        {
            var like = new Like { ImageId = imageId, OwnerId = currentUserName };
            LikeRepository.Delete(like);
        }

        public int GetLikesCount(string imageId)
        {
            return LikeRepository.GetAll().Count(x => x.ImageId == imageId);
        }
    }
}
