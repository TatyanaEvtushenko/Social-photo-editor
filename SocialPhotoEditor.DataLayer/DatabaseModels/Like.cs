using System.ComponentModel.DataAnnotations;

namespace SocialPhotoEditor.DataLayer.DatabaseModels
{
    public class Like
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string OwnerId { get; set; }

        [Required]
        public string ImageId { get; set; }
    }
}