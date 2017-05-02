using System.Linq;
using SocialPhotoEditor.DataLayer.DatabaseModels;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories.Implementations;

namespace SocialPhotoEditor.BuisnessLayer.Services.CommentServices.Implementations
{
    public class CommentService : ICommentService
    {
        private static readonly IChangedRepository<Comment> CommentRepository = new CommentRepository();

        public int GetCommentsCount(string imageId)
        {
            return CommentRepository.GetAll().Count(x => x.ImageId == imageId);
        }
    }
}
