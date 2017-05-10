using System;
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

        public IEnumerable<CommentViewModel> Put(string text, string imageId)
        {
            return Service.AddComment(User.Identity.Name, imageId, text);
        }

        public IEnumerable<CommentViewModel> Delete(string commentatorUserName, string imageId, DateTime time)
        {
            return Service.DeleteComment(commentatorUserName, imageId, time);
        }
    }
}
