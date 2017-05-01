using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialPhotoEditor.Models
{
    public class Like
    {
        public int Id { get; set; } 

        public int OwnerId { get; set; }

        public int ImageId { get; set; }
    }
}