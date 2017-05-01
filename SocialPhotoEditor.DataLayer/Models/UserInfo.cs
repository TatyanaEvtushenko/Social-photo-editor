using System;
using System.ComponentModel.DataAnnotations;

namespace SocialPhotoEditor.Models
{
    public class UserInfo
    {
        [Key]
        public string UserName { get; set; }

        public string AvatarFileName { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime? Birthday { get; set; }

        public int CityId { get; set; }

        public string Subscribe { get; set; }

        public bool IsFemale { get; set; }
    }
}