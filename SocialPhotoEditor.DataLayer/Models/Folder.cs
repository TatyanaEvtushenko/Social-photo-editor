using System.ComponentModel.DataAnnotations;

namespace SocialPhotoEditor.DataLayer.Models
{
    public class Folder
    {
        public string Id { get; set; }

        [Required]
        public string OwnerId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Subscribe { get; set; }
    }
}