using System.ComponentModel.DataAnnotations;

namespace SocialPhotoEditor.DataLayer.DatabaseModels
{
    public class Country
    {
        [Key]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}