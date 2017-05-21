using System.ComponentModel.DataAnnotations;

namespace SocialPhotoEditor.DataLayer.DatabaseModels
{
    public class City
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string CountryName { get; set; }

        [Required]
        public string CityName { get; set; }
    }
}