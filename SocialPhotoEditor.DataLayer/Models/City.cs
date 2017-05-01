using System.ComponentModel.DataAnnotations;

namespace SocialPhotoEditor.DataLayer.Models
{
    public class City
    {
        public int Id { get; set; } 

        [Required]
        public int LandId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}