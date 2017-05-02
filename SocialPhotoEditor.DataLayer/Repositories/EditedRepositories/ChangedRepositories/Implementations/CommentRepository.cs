using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.DataLayer.DatabaseContextes;
using SocialPhotoEditor.DataLayer.DatabaseModels;

namespace SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories.Implementations
{
    public class CommentRepository : IChangedRepository<Comment>
    {
        public List<Comment> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Comments.Select(x => x).ToList();
            }
        }

        public void Add(Comment data)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Comments.Add(data);
                db.SaveChanges();
            }
        }

        public void Delete(Comment data)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Comments.Remove(data);
                db.SaveChanges();
            }
        }

        public List<Comment> Take(int count)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Comments.Take(count).ToList();
            }
        }

        public void Update(Comment data)
        {
            using (var db = new ApplicationDbContext())
            {
                var comment = db.Comments.FirstOrDefault(x => x.Id == data.Id);
                if (comment == null)
                    return;
                comment.Time = data.Time;
                comment.Text = data.Text;
                comment.RecipientId = data.RecipientId;
                db.SaveChanges();
            }
        }
    }
}
