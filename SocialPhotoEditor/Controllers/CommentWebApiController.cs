using System.Web.Http;
using SocialPhotoEditor.BuisnessLayer.Services.CommentServices;
using SocialPhotoEditor.BuisnessLayer.Services.CommentServices.Implementations;
using SocialPhotoEditor.Responses;

namespace SocialPhotoEditor.Controllers
{
    public class CommentWebApiController : ApiController
    {
        private static readonly ICommentService Service = new CommentService();

        [HttpPut]
        public string AddComment(NewCommentResponse response)
        {
            return Service.AddComment(User.Identity.Name, response.ImageId, response.Text, response.RecipientUserName);
        }

        [HttpDelete]
        public bool DeleteComment(string commentId)
        {
            return Service.DeleteComment(commentId);
        }
    }
}
