using System.Collections.Generic;
using System.Web.Http;
using SocialPhotoEditor.BuisnessLayer.Services.CountryServices;
using SocialPhotoEditor.BuisnessLayer.Services.CountryServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.CountryViewModels;

namespace SocialPhotoEditor.Controllers
{
    public class CountryWebApiController : ApiController
    {
        private static ICountryService service = new CountryService();

        // GET: api/LandsWebAPI
        public IEnumerable<CountryViewModel> Get()
        {
            return service.GetCountries();
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
