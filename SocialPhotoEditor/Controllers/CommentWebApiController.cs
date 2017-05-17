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

        public void Put(string text, string imageId, DateTime time, string recipientUserName)
        {
            Service.AddComment(User.Identity.Name, imageId, text, time, recipientUserName);
        }

        public void Delete(string commentatorUserName, string imageId, DateTime time)
        {
            Service.DeleteComment(commentatorUserName, imageId, time);
        }
    }
}
