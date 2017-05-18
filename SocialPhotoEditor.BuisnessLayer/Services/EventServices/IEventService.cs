using System;
using System.Collections.Generic;
using SocialPhotoEditor.BuisnessLayer.ViewModels.EventViewModels;
using SocialPhotoEditor.DataLayer.Enums;

namespace SocialPhotoEditor.BuisnessLayer.Services.EventServices
{
    public interface IEventService
    {
        IEnumerable<EventViewModel> GetEvents(string currentUserName);

        void AddEvent(EventEnum type, string ownerUserName, string recipientUserName, string image, DateTime? time);

        void AddEvent(EventEnum type, string ownerUserName, string image, DateTime? time);

        void DeleteEvent(string ownerUserName, string recipientUserName, DateTime? time);

        void DeleteEvent(string ownerUserName, DateTime? time, string image);
    }
}
