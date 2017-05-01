using System.ComponentModel.DataAnnotations;

namespace SocialPhotoEditor.DataLayer.Models
{
    public class Like
    {
        public string Id { get; set; } 

        [Required]
        public string OwnerId { get; set; }

        [Required]
        public string ImageId { get; set; }
    }
}