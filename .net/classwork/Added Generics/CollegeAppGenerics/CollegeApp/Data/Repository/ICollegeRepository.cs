namespace CollegeApp.Data.Repository
{
    public interface ICollegeRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> GetByName(string name);
        Task<int> Create(T entity);
        Task<int> Update(T entity);
        Task<bool> Delete(int id);
    }
}