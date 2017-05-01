using System.ComponentModel.DataAnnotations;

namespace SocialPhotoEditor.DataLayer.Models
{
    public class Event
    {
        public string Id { get; set; }

        [Required]
        public string OwnerId { get; set; }

        [Required]
        public string Text { get; set; }
    }
}