using System;
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

        public Folder GetFirst(string id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Folders.FirstOrDefault(x => x.Id == id);
            }
        }

        public string Add(Folder data)
        {
            try
            {
                data.Id = Guid.NewGuid().ToString();
                using (var db = new ApplicationDbContext())
                {
                    if (db.Folders.FirstOrDefault(x => x.Id == data.Id) != null)
                        return null;
                    db.Folders.Add(data);
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
                    var data = db.Folders.FirstOrDefault(x => x.Id == id);
                    if (data == null)
                        return false;
                    db.Folders.Remove(data);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(string id, Folder data)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var folder = db.Folders.FirstOrDefault(x => x.Id == id);
                    if (folder == null)
                        return false;
                    folder.Name = data.Name;
                    folder.Subscribe = data.Subscribe;
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
