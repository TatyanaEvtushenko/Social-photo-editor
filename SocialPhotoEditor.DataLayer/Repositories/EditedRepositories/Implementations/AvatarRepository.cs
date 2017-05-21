using System;
using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.DataLayer.DatabaseContextes;
using SocialPhotoEditor.DataLayer.DatabaseModels;

namespace SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.Implementations
{
    public class AvatarRepository : IEditedRepository<Avatar>
    {
        public List<Avatar> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Avatars.ToList();
            }
        }

        public Avatar GetFirst(string id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Avatars.FirstOrDefault(x => x.AvatarFileName == id);
            }
        }

        public string Add(Avatar data)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    if (db.Avatars.FirstOrDefault(x => x.AvatarFileName == data.AvatarFileName) != null)
                        return null;
                    db.Avatars.Add(data);
                    db.SaveChanges();
                }
                return data.AvatarFileName;
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
                    var data = db.Avatars.FirstOrDefault(x => x.AvatarFileName == id);
                    if (data == null)
                        return false;
                    db.Avatars.Remove(data);
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
