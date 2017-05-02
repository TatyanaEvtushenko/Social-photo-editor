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
        private static readonly IRepository<Country> CountryRepository = new CountryRepository();

        public IEnumerable<CountryViewModel> GetCountries()
        {
            var countries = CountryRepository.GetAll();
            var cities = CityRepository.GetAll();
            return countries.Select(country => new CountryViewModel
            {
                Name = country.Name,
                Cities = cities.Where(x => x.CountryId == country.Id).Select(x => x.Name)
            }).ToList();
        }

        public LocationViewModel GetLocation(int cityId)
        {
            var city = CityRepository.GetAll().FirstOrDefault(x => x.Id == cityId);
            var country = CountryRepository.GetAll().FirstOrDefault(x => x.Id == city?.CountryId);
            return new LocationViewModel
            {
                CityName = city?.Name,
                CountryName = country?.Name
            };
        }
    }
}
