using System.ComponentModel.DataAnnotations;

namespace SocialPhotoEditor.DataLayer.DatabaseModels
{
    public class Subscriber
    {
        [Key]
        public string UserName { get; set; }

        [Key]
        public string SubscriberName { get; set; }
    }
}