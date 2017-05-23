using System.Collections.Generic;
using SocialPhotoEditor.BuisnessLayer.ViewModels.ImageViewModels;

namespace SocialPhotoEditor.BuisnessLayer.ViewModels.FolderViewModels
{
    public class FolderViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Subscribe { get; set; }

        public IEnumerable<ImageListViewModel> Images { get; set; }
    }
}
