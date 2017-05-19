using System;
using System.ComponentModel.DataAnnotations;
using SocialPhotoEditor.DataLayer.Enums;

namespace SocialPhotoEditor.DataLayer.DatabaseModels
{
    public class Event
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public EventEnum Type { get; set; }

        [Required]
        public string TypeElementId { get; set; }

        [Required]
        public string RecipientId { get; set; }
        
        [Required]
        public DateTime Time { get; set; }

        [Required]
        public bool IsSeen { get; set; }
    }
}