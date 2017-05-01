using System;
using System.ComponentModel.DataAnnotations;

namespace SocialPhotoEditor.DataLayer.Models
{
    public class Comment
    {
        public string Id { get; set; }

        [Required]
        public string CommentatorId { get; set; }

        [Required]
        public string ImageId { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public string Text { get; set; }

        public string RecipientId { get; set; }
    }
}