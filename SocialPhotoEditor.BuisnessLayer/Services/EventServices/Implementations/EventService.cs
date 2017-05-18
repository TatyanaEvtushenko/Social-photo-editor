using System;
using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.BuisnessLayer.Services.UserServices;
using SocialPhotoEditor.BuisnessLayer.Services.UserServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.EventViewModels;
using SocialPhotoEditor.DataLayer.DatabaseModels;
using SocialPhotoEditor.DataLayer.Enums;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories.Implementations;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.Implementations;
using SociaPhotoEditor.Settings;

namespace SocialPhotoEditor.BuisnessLayer.Services.EventServices.Implementations
{
    public class EventService : IEventService
    {
        private static readonly IEditedRepository<Event> EventRepository = new EventRepository();
        private static readonly IChangedRepository<Image> ImageRepository = new ImageRepository();

        private static readonly IUserService UserService = new UserService();

        public IEnumerable<EventViewModel> GetEvents(string currentUserName)
        {
            return
                EventRepository.GetAll()
                    .Where(x => x.RecipientId == currentUserName)
                    .Take(IntSettings.CountEvents)
                    .Select(x =>
                        new EventViewModel
                        {
                            Owner = UserService.GetUserMinInfo(x.OwnerId),
                            ImageFileName = x.Image,
                            Time = x.Time,
                            Type = x.EventType
                        });
        }

        public void AddEvent(EventEnum type, string ownerUserName, string recipientUserName, string image, DateTime? time)
        {
            var userEvent = new Event
            {
                EventType = type,
                Image = image,
                OwnerId = ownerUserName,
                RecipientId = recipientUserName,
                Time = time
            };
            EventRepository.Add(userEvent);
        }

        public void AddEvent(EventEnum type, string ownerUserName, string image, DateTime? time)
        {
            var recipientUserName = ImageRepository.GetAll().FirstOrDefault(x => x.FileName == image)?.OwnerId;
            AddEvent(type, ownerUserName, recipientUserName, image, time);
        }

        public void DeleteEvent(string ownerUserName, string recipientUserName, DateTime? time)
        {
            var userEvent = new Event
            {
                OwnerId = ownerUserName,
                RecipientId = recipientUserName,
                Time = time
            };
            EventRepository.Delete(userEvent);
        }

        public void DeleteEvent(string ownerUserName, DateTime? time, string image)
        {
            var recipientUserName = ImageRepository.GetAll().FirstOrDefault(x => x.FileName == image)?.OwnerId;
            DeleteEvent(ownerUserName, recipientUserName, time);
        }
    }
}
