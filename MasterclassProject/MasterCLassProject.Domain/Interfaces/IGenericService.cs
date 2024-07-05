namespace MasterClassProject.Domain.Interfaces
{
    public interface IGenericService<T> where T : class, IEntity
    {
        Task<List<T>> GetAll();

        Task<T> GetById(long Id);

        Task<T> Update(T item);

        Task Delete(long id);

        Task<T> Add(T item);
    }
}