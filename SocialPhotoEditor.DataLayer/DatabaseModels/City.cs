using System.ComponentModel.DataAnnotations;

namespace SocialPhotoEditor.DataLayer.DatabaseModels
{
    public class City
    {
        public int Id { get; set; } 

        [Required]
        public int CountryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}