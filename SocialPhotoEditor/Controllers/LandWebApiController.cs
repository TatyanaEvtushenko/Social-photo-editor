using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SocialPhotoEditor.BuisnessLayer.ViewModels.LandViewModels;
using SocialPhotoEditor.Models;

namespace SocialPhotoEditor.Controllers
{
    public class LandWebApiController : ApiController
    {
        // GET: api/LandsWebAPI
        public IEnumerable<LandViewModel> Get()
        {
            using (var db = new ApplicationDbContext())
            {
                return from land in db.Lands.Select(x => x)
                    let cities = db.Cities.Where(x => x.LandId == land.Id).Select(x => x.Name).ToList()
                    select new LandViewModel
                    {
                        Name = land.Name,
                        Cities = cities
                    };
            }
        }

        // GET: api/LandsWebAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/LandsWebAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/LandsWebAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LandsWebAPI/5
        public void Delete(int id)
        {
        }
    }
}
