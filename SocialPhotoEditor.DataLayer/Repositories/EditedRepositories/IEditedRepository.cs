namespace SocialPhotoEditor.DataLayer.Repositories.EditedRepositories
{
    public interface IEditedRepository<T> : IRepository<T>
    {
        string Add(T data);

        bool Delete(string id);
    }
}
