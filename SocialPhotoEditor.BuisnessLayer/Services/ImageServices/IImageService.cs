using System.Collections.Generic;
using SocialPhotoEditor.BuisnessLayer.ViewModels.ImageViewModels;

namespace SocialPhotoEditor.BuisnessLayer.Services.ImageServices
{
    public interface IImageService
    {
        ImageViewModel GetImage(string currentUserName, string imageId);

        IEnumerable<ImageViewModel> GetNews(string currentUserName);
    }
}
