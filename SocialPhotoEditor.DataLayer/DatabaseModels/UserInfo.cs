﻿using System;
using System.ComponentModel.DataAnnotations;
using SocialPhotoEditor.DataLayer.Enums;

namespace SocialPhotoEditor.DataLayer.DatabaseModels
{
    public class UserInfo
    {
        [Key]
        public string UserName { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }

        public string AvatarFileName { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime? Birthday { get; set; }

        public string CityId { get; set; }

        public string Subscribe { get; set; }
        
        public SexEnum Sex { get; set; }
    }
}