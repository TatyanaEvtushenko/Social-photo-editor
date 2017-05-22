using System;

namespace SocialPhotoEditor.BuisnessLayer.ViewModels.CommentViewModels
{
    public class CommentViewModel
    {
        public string Text { get; set; }

        public string OwnerUserName { get; set; }

        public string RecipientUserName { get; set; }

        public DateTime Time { get; set; }

        public string Id { get; set; }
    }
}
