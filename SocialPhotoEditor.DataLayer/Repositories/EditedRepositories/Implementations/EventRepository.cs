using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.DataLayer.DatabaseContextes;
using SocialPhotoEditor.DataLayer.DatabaseModels;

namespace SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.Implementations
{
    public class EventRepository : IEditedRepository<Event>
    {
        public List<Event> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Events.ToList();
            }
        }

        public void Add(Event data)
        {
            using (var db = new ApplicationDbContext())
            {
                if (db.Events.FirstOrDefault(x => x.Time == data.Time && x.OwnerId == data.OwnerId && x.RecipientId == data.RecipientId) != null)
                    return;
                db.Events.Add(data);
                db.SaveChanges();
            }
        }

        public void Delete(Event data)
        {
            using (var db = new ApplicationDbContext())
            {
                data = db.Events.FirstOrDefault(x => x.Time == data.Time && x.OwnerId == data.OwnerId && x.RecipientId == data.RecipientId);
                if (data == null)
                    return;
                db.Events.Remove(data);
                db.SaveChanges();
            }
        }
    }
}
