using System;
using System.ComponentModel.DataAnnotations;

namespace SocialPhotoEditor.DataLayer.DatabaseModels
{
    public class Comment
    {
        [Key]
        public string CommentatorId { get; set; }

        [Key]
        public string ImageId { get; set; }

        [Key]
        public DateTime Time { get; set; }

        [Required]
        public string Text { get; set; }

        public string RecipientId { get; set; }
    }
}