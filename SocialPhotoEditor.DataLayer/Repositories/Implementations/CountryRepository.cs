using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.DataLayer.DatabaseContextes;
using SocialPhotoEditor.DataLayer.DatabaseModels;

namespace SocialPhotoEditor.DataLayer.Repositories.Implementations
{
    public class CountryRepository : IRepository<Country>
    {
        public List<Country> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Lands.ToList();
            }
        }
    }
}
