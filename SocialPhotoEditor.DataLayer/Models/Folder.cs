using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialPhotoEditor.Models
{
    public class Folder
    {
        public string Id { get; set; }

        public string OwnerUserName { get; set; }

        public string Name { get; set; }

        public string Subscribe { get; set; }
    }
}