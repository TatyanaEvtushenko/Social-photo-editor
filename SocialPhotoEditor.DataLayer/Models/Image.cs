using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialPhotoEditor.Models
{
    public class Image
    {
        public int Id { get; set; }

        public int OwnerId { get; set; }

        public string Path { get; set; }

        public int FolderId { get; set; }

        public DateTime Date { get; set; }

        public DateTime Time { get; set; }
    }
}