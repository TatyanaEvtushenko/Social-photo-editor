using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                return db.Comments.ToList();
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
                var comment = db.Comments.FirstOrDefault(x => x.Time == data.Time && x.ImageId == data.ImageId && x.CommentatorId == data.CommentatorId);
                if (comment == null)
                    return;
                comment.Text = data.Text;
                comment.RecipientId = data.RecipientId;
                db.SaveChanges();
            }
        }
    }
}
