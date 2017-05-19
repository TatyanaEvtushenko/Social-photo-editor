using System.Collections.Generic;
using SocialPhotoEditor.BuisnessLayer.ViewModels.CountryViewModels;

namespace SocialPhotoEditor.BuisnessLayer.Services.CountryServices
{
    public interface ICountryService
    {
        IEnumerable<CountryViewModel> GetCountries();
    }
}
