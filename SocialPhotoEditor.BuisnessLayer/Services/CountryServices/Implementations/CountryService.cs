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
            var cities = CityRepository.GetAll();
            return CountryRepository.GetAll().Select(country => new CountryViewModel
            {
                Name = country.Name,
                Cities = cities.Where(x => x.CountryName == country.Name).Select(x => x.Name)
            });
        }

        public LocationViewModel GetLocation(int cityId)
        {
            var city = CityRepository.GetAll().FirstOrDefault(x => x.Id == cityId);
            if (city == null)
                return null;
            return new LocationViewModel
            {
                City = city.Name,
                Country = city.CountryName
            };
        }
    }
}
