using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialPhotoEditor.Models
{
    public class Subscriber
    {
        [Key]
        public string UserName { get; set; }

        [Key]
        public string SubscriberName { get; set; }
    }
}