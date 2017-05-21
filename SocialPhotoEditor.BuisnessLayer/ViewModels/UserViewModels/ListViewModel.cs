using System.Collections.Generic;

namespace SocialPhotoEditor.BuisnessLayer.ViewModels.UserViewModels
{
    public class ListViewModel
    {
        public int UsersCount { get; set; }

        public IEnumerable<UserListViewModel> Users { get; set; }
    }
}
