using System;
using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.DataLayer.DatabaseContextes;
using SocialPhotoEditor.DataLayer.DatabaseModels;

namespace SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories.Implementations
{
    public class EventRepository : IChangedRepository<Event>
    {
        public List<Event> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Events.ToList();
            }
        }

        public Event GetFirst(string id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Events.FirstOrDefault(x => x.Id == id);
            }
        }

        public string Add(Event data)
        {
            try
            {
                data.IsSeen = false;
                data.Time = DateTime.UtcNow;
                data.Id = Guid.NewGuid().ToString();
                using (var db = new ApplicationDbContext())
                {
                    if (db.Events.FirstOrDefault(x => x.Id == data.Id) != null)
                        return null;
                    db.Events.Add(data);
                    db.SaveChanges();
                }
                return data.Id;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var data = db.Events.FirstOrDefault(x => x.Id == id);
                    if (data == null)
                        return false;
                    db.Events.Remove(data);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(string id, Event data)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var userEvent = db.Events.FirstOrDefault(x => x.Id == id);
                    if (userEvent == null)
                        return false;
                    userEvent.IsSeen = data.IsSeen;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
