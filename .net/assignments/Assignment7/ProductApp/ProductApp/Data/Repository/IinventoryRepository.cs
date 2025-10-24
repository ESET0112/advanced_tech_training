
namespace ProductApp.Data.Repository
{

    public interface IinventoryRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<int> Create(T entity);
        Task<int> Update(int id, T entity);
        Task<bool> Delete(int id);
    }
}
