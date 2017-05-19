using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.DataLayer.DatabaseContextes;
using SocialPhotoEditor.DataLayer.DatabaseModels;

namespace SocialPhotoEditor.DataLayer.Repositories.Implementations
{
    public class CityRepository : IRepository<City>
    {
        public List<City> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Cities.ToList();
            }
        }

        public City GetFirst(string id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Cities.FirstOrDefault(x => x.Id == id);
            }
        }
    }
}

