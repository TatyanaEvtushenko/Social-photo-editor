namespace SocialPhotoEditor.DataLayer.Repositories.EditedRepositories
{
    public interface IEditedRepository<T> : IRepository<T>
    {
        void Add(T data);

        void Delete(T data);
    }
}
