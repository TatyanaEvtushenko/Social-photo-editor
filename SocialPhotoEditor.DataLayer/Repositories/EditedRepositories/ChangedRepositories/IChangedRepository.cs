using System.Collections.Generic;

namespace SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories
{
    public interface IChangedRepository<T> : IEditedRepository<T>
    {
        List<T> Take(int count);

        void Update(T data);
    }
}
