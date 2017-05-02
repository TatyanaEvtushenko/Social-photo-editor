using System.Collections.Generic;

namespace SocialPhotoEditor.DataLayer.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll();
    }
}
