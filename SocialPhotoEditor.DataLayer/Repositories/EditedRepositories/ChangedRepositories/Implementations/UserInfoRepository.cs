using System;
using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.DataLayer.DatabaseContextes;
using SocialPhotoEditor.DataLayer.DatabaseModels;

namespace SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories.Implementations
{
    public class UserInfoRepository : IChangedRepository<UserInfo>
    {
        public List<UserInfo> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.UserInfos.ToList();
            }
        }

        public UserInfo GetFirst(string id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.UserInfos.FirstOrDefault(x => x.UserName == id);
            }
        }

        public string Add(UserInfo data)
        {
            try
            {
                data.RegisterDate = DateTime.Now;
                using (var db = new ApplicationDbContext())
                {
                    if (db.UserInfos.FirstOrDefault(x => x.UserName == data.UserName) != null)
                        return null;
                    db.UserInfos.Add(data);
                    db.SaveChanges();
                }
                return data.UserName;
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
                    var data = db.UserInfos.FirstOrDefault(x => x.UserName == id);
                    if (data == null)
                        return false;
                    db.UserInfos.Remove(data);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(string id, UserInfo data)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var info = db.UserInfos.FirstOrDefault(x => x.UserName == id);
                    if (info == null)
                        return false;
                    info.AvatarFileName = data.AvatarFileName;
                    info.Birthday = data.Birthday;
                    info.CityId = data.CityId;
                    info.Name = data.Name;
                    info.Surname = data.Surname;
                    info.Subscribe = data.Subscribe;
                    info.Sex = data.Sex;
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
