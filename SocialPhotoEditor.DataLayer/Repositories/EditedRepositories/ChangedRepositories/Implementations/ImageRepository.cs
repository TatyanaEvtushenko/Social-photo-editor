using System;
using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.DataLayer.DatabaseContextes;
using SocialPhotoEditor.DataLayer.DatabaseModels;

namespace SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories.Implementations
{
    public class ImageRepository : IChangedRepository<Image>
    {
        public List<Image> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Images.ToList();
            }
        }

        public Image GetFirst(string id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Images.FirstOrDefault(x => x.FileName == id);
            }
        }

        public string Add(Image data)
        {
            try
            {
                data.Time = DateTime.UtcNow;
                using (var db = new ApplicationDbContext())
                {
                    if (db.Images.FirstOrDefault(x => x.FileName == data.FileName) != null)
                        return null;
                    db.Images.Add(data);
                    db.SaveChanges();
                }
                return data.FileName;
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
                    var data = db.Images.FirstOrDefault(x => x.FileName == id);
                    if (data == null)
                        return false;
                    db.Images.Remove(data);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(string id, Image data)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var image = db.Images.FirstOrDefault(x => x.FileName == id);
                    if (image == null)
                        return false;
                    image.FolderId = data.FolderId;
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
