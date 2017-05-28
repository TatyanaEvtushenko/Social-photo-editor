using System;
using SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels;
using SocialPhotoEditor.DataLayer.Enums;

namespace SocialPhotoEditor.BuisnessLayer.ViewModels.EventViewModels
{
    public class EventViewModel
    {
        public UserMinInfoViewModel Owner { get; set; }

        public string ImageFileName { get; set; }

        public EventEnum Type { get; set; }

        public DateTime Time { get; set; }

        public bool IsSeen { get; set; }
    }
}
