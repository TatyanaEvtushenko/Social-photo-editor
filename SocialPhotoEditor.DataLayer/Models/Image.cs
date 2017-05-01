using System;
using System.ComponentModel.DataAnnotations;

namespace SocialPhotoEditor.DataLayer.Models
{
    public class Image
    {
        [Key]
        public string FieName { get; set; }

        [Required]
        public string OwnerId { get; set; }
        
        public string FolderId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime Time { get; set; }
    }
}