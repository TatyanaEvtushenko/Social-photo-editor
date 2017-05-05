using System;
using System.ComponentModel.DataAnnotations;

namespace SocialPhotoEditor.DataLayer.DatabaseModels
{
    public class Image
    {
        [Key]
        public string FileName { get; set; }

        [Required]
        public string OwnerId { get; set; }
        
        public string FolderId { get; set; }
        
        [Required]
        public DateTime Time { get; set; }
    }
}