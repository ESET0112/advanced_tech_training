using EmployeeApp.Models;

namespace EmployeeApp.Data.Repository
{
    public interface IEmployeeRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(int id,T entity);
        Task DeleteAsync(int id);

    }
}
