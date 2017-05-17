using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.DataLayer.DatabaseContextes;
using SocialPhotoEditor.DataLayer.DatabaseModels;

namespace SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories.Implementations
{
    public class FolderRepository : IChangedRepository<Folder>
    {
        public List<Folder> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Folders.ToList();
            }
        }

        public void Add(Folder data)
        {
            using (var db = new ApplicationDbContext())
            {
                if (db.Folders.FirstOrDefault(x => x.Id == data.Id) != null)
                    return;
                db.Folders.Add(data);
                db.SaveChanges();
            }
        }

        public void Delete(Folder data)
        {
            using (var db = new ApplicationDbContext())
            {
                data = db.Folders.FirstOrDefault(x => x.Id == data.Id);
                if (data == null)
                    return;
                db.Folders.Remove(data);
                db.SaveChanges();
            }
        }

        public List<Folder> Take(int count)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Folders.Take(count).ToList();
            }
        }

        public void Update(Folder data)
        {
            using (var db = new ApplicationDbContext())
            {
                var folder = db.Folders.FirstOrDefault(x => x.Id == data.Id);
                if (folder == null)
                    return;
                folder.Name = data.Name;
                folder.Subscribe = data.Subscribe;
                db.SaveChanges();
            }
        }
    }
}
