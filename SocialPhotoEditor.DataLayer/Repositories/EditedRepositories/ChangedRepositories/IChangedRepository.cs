namespace SocialPhotoEditor.DataLayer.Repositories.EditedRepositories.ChangedRepositories
{
    public interface IChangedRepository<T> : IEditedRepository<T>
    {
        bool Update(string id, T data);
    }
}
