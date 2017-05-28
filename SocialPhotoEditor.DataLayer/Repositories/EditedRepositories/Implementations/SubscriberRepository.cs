using System;
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

        public Subscriber GetFirst(string id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Subscribers.FirstOrDefault(x => x.Id == id);
            }
        }

        public string Add(Subscriber data)
        {
            try
            {
                data.Id = Guid.NewGuid().ToString();
                using (var db = new ApplicationDbContext())
                {
                    if (db.Subscribers.FirstOrDefault(x => x.Id == data.Id) != null)
                        return null;
                    db.Subscribers.Add(data);
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
                    var data = db.Subscribers.FirstOrDefault(x => x.Id == id);
                    if (data == null)
                        return false;
                    db.Subscribers.Remove(data);
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
