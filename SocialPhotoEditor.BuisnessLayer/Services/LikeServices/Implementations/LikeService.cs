using System;
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

        public void AddLike(string currentUserName, string imageId)
        {
            var like = new Like { ImageId = imageId, OwnerId = currentUserName };
            LikeRepository.Add(like);
            EventService.AddEvent(EventEnum.Like, currentUserName, imageId, null);
        }

        public void DeleteLike(string currentUserName, string imageId)
        {
            var like = new Like { ImageId = imageId, OwnerId = currentUserName };
            LikeRepository.Delete(like);
            EventService.DeleteEvent(currentUserName, null, imageId);
        }

        public int GetLikesCount(string imageId)
        {
            return LikeRepository.GetAll().Count(x => x.ImageId == imageId);
        }
    }
}
