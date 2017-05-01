using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialPhotoEditor.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int CommentatorId { get; set; }

        public int ImageId { get; set; }

        public DateTime Time { get; set; }

        public string Text { get; set; }

        public int RecipientId { get; set; }
    }
}