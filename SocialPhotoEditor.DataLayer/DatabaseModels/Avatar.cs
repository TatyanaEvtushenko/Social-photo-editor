using System.ComponentModel.DataAnnotations;

namespace SocialPhotoEditor.DataLayer.DatabaseModels
{
    public class Avatar
    {
        [Key]
        public string AvatarFileName { get; set; }

        public string ImageId { get; set; }

        [Required]
        public string OwnerId { get; set; }
    }
}
