using System;
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
                return db.Comments.ToList();
            }
        }

        public Comment GetFirst(string id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Comments.FirstOrDefault(x => x.Id == id);
            }
        }

        public string Add(Comment data)
        {
            try
            {
                data.Time = DateTime.Now;
                data.Id = data.CommentatorId + data.Time + data.ImageId.GetHashCode();
                using (var db = new ApplicationDbContext())
                {
                    if (db.Comments.FirstOrDefault(x => x.Id == data.Id) != null)
                        return null;
                    db.Comments.Add(data);
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
                    var data = db.Comments.FirstOrDefault(x => x.Id == id);
                    if (data == null)
                        return false;
                    db.Comments.Remove(data);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(string id, Comment data)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var comment = db.Comments.FirstOrDefault(x => x.Id == id);
                    if (comment == null)
                        return false;
                    comment.Text = data.Text;
                    comment.RecipientId = data.RecipientId;
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
