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
                return db.Images.Select(x => x).ToList();
            }
        }

        public List<Image> Take(int count)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Images.Take(count).ToList();
            }
        }

        public void Add(Image data)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Images.Add(data);
                db.SaveChanges();
            }
        }

        public void Update(Image data)
        {
            using (var db = new ApplicationDbContext())
            {
                var image = db.Images.FirstOrDefault(x => x.FileName == data.FileName);
                if (image == null)
                    return;
                image.FolderId = data.FolderId;
                db.SaveChanges();
            }
        }

        public void Delete(Image data)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Images.Remove(data);
                db.SaveChanges();
            }
        }
    }
}
