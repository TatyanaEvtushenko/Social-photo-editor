using System.Collections.Generic;
using System.Web.Http;
using SocialPhotoEditor.BuisnessLayer.Services.CommentServices;
using SocialPhotoEditor.BuisnessLayer.Services.CommentServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.CommentViewModels;

namespace SocialPhotoEditor.Controllers
{
    public class CommentWebApiController : ApiController
    {
        private static readonly ICommentService Service = new CommentService();

        public IEnumerable<CommentViewModel> Post(string imageFileName)
        {
            return Service.GetComments(imageFileName);
        }

        public string Put(string text, string imageId, string recipientUserName)
        {
            return Service.AddComment(User.Identity.Name, imageId, text, recipientUserName);
        }

        public bool Delete(string commentId)
        {
            return Service.DeleteComment(commentId);
        }
    }
}
