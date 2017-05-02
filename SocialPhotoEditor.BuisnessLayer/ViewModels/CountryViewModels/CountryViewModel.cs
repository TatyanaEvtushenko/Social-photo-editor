using System.Collections.Generic;

namespace SocialPhotoEditor.BuisnessLayer.ViewModels.CountryViewModels
{
    public class CountryViewModel
    {
        public string Name { get; set; }

        public IEnumerable<string> Cities { get; set; }
    }
}