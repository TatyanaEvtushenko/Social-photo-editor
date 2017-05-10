using System.Linq;
using SocialPhotoEditor.BuisnessLayer.ViewModels.LikeViewModels;
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

        public void ChangeLike(string imageId, string userName)
        {
            var like = LikeRepository.GetAll().FirstOrDefault(x => x.ImageId == imageId && x.OwnerId == userName);
            if (like == null)
            {
                like = new Like {ImageId = imageId, OwnerId = userName};
                LikeRepository.Add(like);
            }
            else
            {
                LikeRepository.Delete(like);
            }
        }

        public LikeViewModel GetLike(string imageId, string userName)
        {
            var likes = LikeRepository.GetAll().Where(x => x.ImageId == imageId);
            return new LikeViewModel
            {
                Count = likes.Count(),
                IsLiked = likes.FirstOrDefault(x => x.OwnerId == userName) != null
            };
        }

        public bool CheckLiked(string imageId, string userName)
        {
            return LikeRepository.GetAll().FirstOrDefault(x => x.ImageId == imageId && x.OwnerId == userName) != null;
        }
    }
}
