using System.ComponentModel.DataAnnotations;

namespace SocialPhotoEditor.DataLayer.DatabaseModels
{
    public class Subscriber
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string SubscriberName { get; set; }
    }
}