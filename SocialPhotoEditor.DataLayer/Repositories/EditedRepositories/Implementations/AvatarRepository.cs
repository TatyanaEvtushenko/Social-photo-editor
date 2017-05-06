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

        public void Add(Avatar data)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Avatars.Add(data);
                db.SaveChanges();
            }
        }

        public void Delete(Avatar data)
        {
            using (var db = new ApplicationDbContext())
            {
                data = db.Avatars.FirstOrDefault(x => x.AvatarFileName == data.AvatarFileName);
                if (data == null)
                    return;
                db.Avatars.Remove(data);
                db.SaveChanges();
            }
        }
    }
}
