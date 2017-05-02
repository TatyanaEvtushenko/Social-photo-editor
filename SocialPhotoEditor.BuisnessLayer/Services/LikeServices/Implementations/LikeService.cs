using System.Linq;
using SocialPhotoEditor.DataLayer.DatabaseModels;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.Implementations;

namespace SocialPhotoEditor.BuisnessLayer.Services.LikeServices.Implementations
{
    public class LikeService : ILikeService
    {
        private static readonly IEditedRepository<Like> LikeRepository = new LikeRepository();

        public int GetLikesCount(string imageId)
        {
            return LikeRepository.GetAll().Count(x => x.ImageId == imageId);
        }
    }
}
