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
                return db.Likes.Select(x => x).ToList();
            }
        }

        public void Add(Like data)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Likes.Add(data);
                db.SaveChanges();
            }
        }

        public void Delete(Like data)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Likes.Remove(data);
                db.SaveChanges();
            }
        }
    }
}
