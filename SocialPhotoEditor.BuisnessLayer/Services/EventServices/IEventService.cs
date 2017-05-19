using System;
using System.Collections.Generic;
using SocialPhotoEditor.BuisnessLayer.ViewModels.EventViewModels;
using SocialPhotoEditor.DataLayer.Enums;

namespace SocialPhotoEditor.BuisnessLayer.Services.EventServices
{
    public interface IEventService
    {
        IEnumerable<EventViewModel> GetEvents(string currentUserName);

        void AddEvent(EventEnum type, string elementId, string recipientUserName);

        void AddEvent(string image, EventEnum type, string elementId);

        void DeleteEvent(EventEnum typeElement, string elementId);
    }
}
