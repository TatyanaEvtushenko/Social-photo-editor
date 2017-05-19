using System.Linq;
using SocialPhotoEditor.BuisnessLayer.Services.EventServices;
using SocialPhotoEditor.BuisnessLayer.Services.EventServices.Implementations;
using SocialPhotoEditor.DataLayer.DatabaseModels;
using SocialPhotoEditor.DataLayer.Enums;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.Implementations;

namespace SocialPhotoEditor.BuisnessLayer.Services.LikeServices.Implementations
{
    public class LikeService : ILikeService
    {
        private static readonly IEditedRepository<Like> LikeRepository = new LikeRepository();

        private static readonly IEventService EventService = new EventService();

        public string AddLike(string currentUserName, string imageId)
        {
            var like = new Like { ImageId = imageId, OwnerId = currentUserName };
            var likeId = LikeRepository.Add(like);
            if (likeId != null)
            {
                EventService.AddEvent(imageId, EventEnum.Like, likeId);
            }
            return likeId;
        }

        public bool DeleteLike(string id)
        {
            var result = LikeRepository.Delete(id);
            if (result)
            {
                EventService.DeleteEvent(EventEnum.Like, id);
            }
            return result;
        }

        public int GetLikesCount(string imageId)
        {
            return LikeRepository.GetAll().Count(x => x.ImageId == imageId);
        }
    }
}
