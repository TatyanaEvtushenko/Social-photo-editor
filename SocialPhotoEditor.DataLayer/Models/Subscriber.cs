using System.ComponentModel.DataAnnotations;

namespace SocialPhotoEditor.DataLayer.Models
{
    public class Subscriber
    {
        [Key]
        public string UserName { get; set; }

        [Key]
        public string SubscriberName { get; set; }
    }
}