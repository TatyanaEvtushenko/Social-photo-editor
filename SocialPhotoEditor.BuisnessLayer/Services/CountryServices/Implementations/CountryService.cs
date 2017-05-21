using System.Collections.Generic;
using System.Linq;
using SocialPhotoEditor.BuisnessLayer.ViewModels.CountryViewModels;
using SocialPhotoEditor.DataLayer.DatabaseModels;
using SocialPhotoEditor.DataLayer.Repositories;
using SocialPhotoEditor.DataLayer.Repositories.Implementations;

namespace SocialPhotoEditor.BuisnessLayer.Services.CountryServices.Implementations
{
    public class CountryService : ICountryService
    {
        private static readonly IRepository<City> CityRepository = new CityRepository();

        public IEnumerable<CountryViewModel> GetCountries()
        {
            var cities = CityRepository.GetAll().GroupBy(x => x.CountryName, x => x.CityName);
            return cities.Select(x => new CountryViewModel {Name = x.Key, Cities = x.AsEnumerable()});
        }
    }
}
