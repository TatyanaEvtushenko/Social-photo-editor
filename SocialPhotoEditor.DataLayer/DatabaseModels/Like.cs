using System.ComponentModel.DataAnnotations;

namespace SocialPhotoEditor.DataLayer.DatabaseModels
{
    public class Like
    {
        [Key]
        public string OwnerId { get; set; }

        [Key]
        public string ImageId { get; set; }
    }
}