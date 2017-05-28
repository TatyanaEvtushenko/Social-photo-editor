using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.BuisnessLayer.Services.UserServices;
using SocialPhotoEditor.BuisnessLayer.Services.UserServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.EventViewModels;
using SocialPhotoEditor.DataLayer.DatabaseModels;
using SocialPhotoEditor.DataLayer.Enums;
using SocialPhotoEditor.DataLayer.Repositories;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories.Implementations;
using SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.Implementations;
using SociaPhotoEditor.Settings;

namespace SocialPhotoEditor.BuisnessLayer.Services.EventServices.Implementations
{
    public class EventService : IEventService
    {
        private static readonly IChangedRepository<Event> EventRepository = new EventRepository();
        private static readonly IRepository<Image> ImageRepository = new ImageRepository();
        private static readonly IRepository<Comment> CommentRepository = new CommentRepository();
        private static readonly IRepository<Like> LikeRepository = new LikeRepository();
        private static readonly IRepository<Subscriber> SubscriberRepository = new SubscriberRepository();

        private static readonly IUserService UserService = new UserService();

        public IEnumerable<EventViewModel> GetEvents(string currentUserName)
        {
            var events = EventRepository.GetAll().Where(x => x.RecipientId == currentUserName).Take(IntSettings.CountEvents);
            var result = new List<EventViewModel>();
            foreach (var userEvent in events)
            {
                var eventViewModel = new EventViewModel {Time = userEvent.Time, Type = userEvent.Type};
                switch (userEvent.Type)
                {
                    case EventEnum.Comment:
                    case EventEnum.CommentAnswer:
                        var comment = CommentRepository.GetFirst(userEvent.TypeElementId);
                        eventViewModel.ImageFileName = userEvent.Type == EventEnum.CommentAnswer ? null : comment.ImageId;
                        eventViewModel.Owner = UserService.GetUserMinInfo(comment.CommentatorId);
                        break;
                    case EventEnum.Like:
                        var like = LikeRepository.GetFirst(userEvent.TypeElementId);
                        eventViewModel.ImageFileName = like.ImageId;
                        eventViewModel.Owner = UserService.GetUserMinInfo(like.OwnerId);
                        break;
                    case EventEnum.Subscription:
                        var subscription = SubscriberRepository.GetFirst(userEvent.TypeElementId);
                        eventViewModel.ImageFileName = null;
                        eventViewModel.Owner = UserService.GetUserMinInfo(subscription.SubscriberName);
                        break;
                    default:
                        continue;
                }
                result.Add(eventViewModel);
            }
            SeeNewEvents(currentUserName);
            return result;
        }

        public int SeeNewEvents(string userName)
        {
            var events = EventRepository.GetAll().Where(x => x.RecipientId == userName && x.IsSeen == false);
            var seenEvent = new Event {IsSeen = true};
            return events.Count(x => EventRepository.Update(x.Id, seenEvent));
        }

        public void AddEvent(string currentUserName, EventEnum type, string elementId, string recipientUserName)
        {
            if (currentUserName == recipientUserName) return;
            var userEvent = new Event {Type = type, TypeElementId = elementId, RecipientId = recipientUserName};
            EventRepository.Add(userEvent);
        }

        public void AddEvent(string currentUserName, string image, EventEnum type, string elementId)
        {
            var recipientUserName = ImageRepository.GetFirst(image)?.OwnerId;
            AddEvent(currentUserName, type, elementId, recipientUserName);
        }

        public void DeleteEvent(EventEnum typeElement, string elementId)
        {
            var id = EventRepository.GetAll().FirstOrDefault(x => x.Type == typeElement && x.TypeElementId == elementId)?.Id;
            EventRepository.Delete(id);
        }
    }
}
