using EmployeeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Data.Repository
{
    public class EmployeeRepository<T>: IEmployeeRepository<T> where T : class
    {
        private readonly EmployeeDbContext _dbcontext;
        private readonly DbSet<T> _dbSet;

        public EmployeeRepository(EmployeeDbContext dbContext)
        {
            _dbcontext = dbContext;
            _dbSet = _dbcontext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            if (typeof(T) == typeof(Employee))
            {
                var employees = await _dbcontext.Employees
                                .Where(n => n.EmployeeId == id)
                                .FirstOrDefaultAsync();
                return (T)(object)employees;
            }
            else if (typeof(T) == typeof(User))
            {
                var employees = await _dbcontext.Users
                                .Where(n => n.UserId == id)
                                .FirstOrDefaultAsync();
                return (T)(object)employees;
            }
            return null;
        }
        public async Task AddAsync(T entity)
        {
            _dbSet.Add(entity);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, T entity)
        {
            var existingEntity = await GetByIdAsync(id);
            
            // Get the primary key property name
            var keyPropertyName = _dbcontext.Model.FindEntityType(typeof(T))
                .FindPrimaryKey().Properties.First().Name;

            // Copy all properties EXCEPT the primary key
            foreach (var property in _dbcontext.Entry(existingEntity).Properties)
            {
                if (property.Metadata.Name != keyPropertyName)
                {
                    var newValue = typeof(T).GetProperty(property.Metadata.Name)?.GetValue(entity);
                    if (newValue != null)
                    {
                        property.CurrentValue = newValue;
                        property.IsModified = true;
                    }
                }
            }

            await _dbcontext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _dbcontext.SaveChangesAsync();
                
            }
        }
    }
}
