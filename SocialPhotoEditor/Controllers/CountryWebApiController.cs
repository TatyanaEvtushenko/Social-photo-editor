using System.Collections.Generic;
using System.Web.Http;
using SocialPhotoEditor.BuisnessLayer.Services.CountryServices;
using SocialPhotoEditor.BuisnessLayer.Services.CountryServices.Implementations;
using SocialPhotoEditor.BuisnessLayer.ViewModels.CountryViewModels;

namespace SocialPhotoEditor.Controllers
{
    public class CountryWebApiController : ApiController
    {
        private static readonly ICountryService Service = new CountryService();
        
        [HttpGet]
        public IEnumerable<CountryViewModel> GetCountries()
        {
            return Service.GetCountries();
        }
    }
}
