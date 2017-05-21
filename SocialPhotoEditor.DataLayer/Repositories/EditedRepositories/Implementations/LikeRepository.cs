using System;
using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.DataLayer.DatabaseContextes;
using SocialPhotoEditor.DataLayer.DatabaseModels;

namespace SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.Implementations
{
    public class LikeRepository : IEditedRepository<Like>
    {
        public List<Like> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Likes.ToList();
            }
        }

        public Like GetFirst(string id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Likes.FirstOrDefault(x => x.Id == id);
            }
        }

        public string Add(Like data)
        {
            try
            {
                data.Id = data.ImageId + data.OwnerId + DateTime.Now;
                using (var db = new ApplicationDbContext())
                {
                    if (db.Likes.FirstOrDefault(x => x.Id == data.Id) != null)
                        return null;
                    db.Likes.Add(data);
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
                    var data = db.Likes.FirstOrDefault(x => x.Id == id);
                    if (data == null)
                        return false;
                    db.Likes.Remove(data);
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
