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

        public IEnumerable<CommentViewModel> PostGetComments(string imageFileName)
        {
            return Service.GetComments(imageFileName);
        }

        public void Put(string text, string imageId)
        {
            Service.AddComment(User.Identity.Name, imageId, text);
        }

        public void Delete(string text, string imageId)
        {
            Service.AddComment(User.Identity.Name, imageId, text);
        }
    }
}
