using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.DataLayer.DatabaseContextes;
using SocialPhotoEditor.DataLayer.DatabaseModels;

namespace SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.Implementations
{
    public class SubscriberRepository : IEditedRepository<Subscriber>
    {
        public List<Subscriber> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Subscribers.ToList();
            }
        }

        public void Add(Subscriber data)
        {
            using (var db = new ApplicationDbContext())
            {
                if (db.Subscribers.FirstOrDefault(x => x.UserName == data.UserName && x.SubscriberName == data.SubscriberName) != null)
                    return;
                db.Subscribers.Add(data);
                db.SaveChanges();
            }
        }

        public void Delete(Subscriber data)
        {
            using (var db = new ApplicationDbContext())
            {
                data = db.Subscribers.FirstOrDefault(x => x.UserName == data.UserName && x.SubscriberName == data.SubscriberName);
                if (data == null)
                    return;
                db.Subscribers.Remove(data);
                db.SaveChanges();
            }
        }
    }
}
