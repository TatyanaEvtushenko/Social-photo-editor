using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels;
using SocialPhotoEditor.Models;
using SociaPhotoEditor.Settings;

namespace SocialPhotoEditor.Controllers
{
    public enum UsersCategorie { All, Subscribers, Subscriptions, Friends }

    public class UserWebApiController : ApiController
    {
        private readonly int maxCountUsersOnPage = 20;
        private readonly string defaultAvatarFileName = StringSettings.DefaultAvatar;

        private int GetAge(DateTime? birthday)
        {
            if (birthday == null)
                return 0;
            var yearSubtract = DateTime.Today.Year - birthday.Value.Year;
            if (DateTime.Today.Month < birthday.Value.Month ||
                DateTime.Today.Month == birthday.Value.Month && DateTime.Today.Day < birthday.Value.Day)
                return yearSubtract - 1;
            return yearSubtract;
        }

        //GET
        public IEnumerable<UserListViewModels> Get()
        {
            var users = new List<UserListViewModels>();
            using (var db = new ApplicationDbContext())
            {
                var infos = db.UserInfos.Take(maxCountUsersOnPage);
                foreach (var info in infos)
                {
                    var user = new UserListViewModels
                    {
                        UserName = info.UserName,
                        AvatarFileName = info.AvatarFileName ?? defaultAvatarFileName,
                        Name = $"{info.Name} {info.Surname}",
                        IsFemale = info.IsFemale,
                        Age = GetAge(info.Birthday),
                       // IsSubscriber = db.Subscribers.FirstOrDefault(x => x.UserName == info.UserName && x.SubscriberName == User.Identity.Name) != null
                    };
                    //if (info.CityId != 0)
                    //{
                    //    var city = db.Cities.Where(x => x.Id == info.CityId).ToList()[0];
                    //    user.City = city?.Name;
                    //    user.Land = db.Lands.FirstOrDefault(x => x.Id == city.LandId)?.Name;
                    //}
                    users.Add(user);
                }
            }
            return users;
        }

        //
        //public UserPageViewModels Get(string userName)
        //{
        //    //using (var db = new ApplicationDbContext())
        //    //{
        //    //    var info = db.UserInfos.FirstOrDefault(x => x.UserName == userName);
        //    //    var folders = from folder in db.Folders
        //    //                  where folder.OwnerUserName == userName
        //    //                  select new FolderViewModels
        //    //                  {
        //    //                      Id = folder.Id,
        //    //                      Name = folder.Name
        //    //                  };
        //    //    var user = new UserPageViewModels
        //    //    {
        //    //        AvatarFileName = info.AvatarFileName,
        //    //        Birthday = info.Birthday,
        //    //        Name = $"{info.Name} {info.Surname}",
        //    //        Folders = folders.ToList(),
        //    //    };
        //    //}
        //    return new UserPageViewModels();
        //}

        // POST: api/Test
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }
    }
}
