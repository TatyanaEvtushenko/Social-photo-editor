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

        public List<UserInfo> Take(int count)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.UserInfos.Take(count).ToList();
            }
        }

        public void Add(UserInfo data)
        {
            using (var db = new ApplicationDbContext())
            {
                if (db.UserInfos.FirstOrDefault(x => x.UserName == data.UserName) != null)
                    return;
                db.UserInfos.Add(data);
                db.SaveChanges();
            }
        }

        public void Update(UserInfo data)
        {
            using (var db = new ApplicationDbContext())
            {
                var info = db.UserInfos.FirstOrDefault(x => x.UserName == data.UserName);
                if (info == null)
                    return;
                info.AvatarFileName = data.AvatarFileName;
                info.Birthday = data.Birthday;
                info.CityId = data.CityId;
                info.Name = data.Name;
                info.Surname = data.Surname;
                info.Subscribe = data.Subscribe;
                info.Sex = data.Sex;
                db.SaveChanges();
            }
        }

        public void Delete(UserInfo data)
        {
            using (var db = new ApplicationDbContext())
            {
                data = db.UserInfos.FirstOrDefault(x => x.UserName == data.UserName);
                if (data == null)
                    return;
                db.UserInfos.Remove(data);
                db.SaveChanges();
            }
        }
    }
}
