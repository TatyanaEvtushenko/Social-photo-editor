using System;
using System.ComponentModel.DataAnnotations;
using SocialPhotoEditor.DataLayer.Enums;

namespace SocialPhotoEditor.DataLayer.DatabaseModels
{
    public class Event
    {
        [Required]
        public EventEnum EventType { get; set; }

        [Key]
        public string RecipientId { get; set; }

        [Key]
        public string OwnerId { get; set; }
        
        [Key]
        public DateTime? Time { get; set; }

        public string Image { get; set; }

        public bool IsSeen { get; set; }
    }
}