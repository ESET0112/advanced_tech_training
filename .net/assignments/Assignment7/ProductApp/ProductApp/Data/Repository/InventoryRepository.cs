using Microsoft.EntityFrameworkCore;
using ProductApp.Models;

namespace ProductApp.Data.Repository
{
    public class InventoryRepository<T> : IinventoryRepository<T> where T : class
    {
        private readonly InventoryContext _dbcontext;
        private readonly DbSet<T> _dbSet;

        public InventoryRepository(InventoryContext dbcontext)
        {
            _dbcontext = dbcontext;
            _dbSet = _dbcontext.Set<T>();
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            if (typeof(T) == typeof(Category))
            {
                var categories = await _dbcontext.Categories
                       .Where(n => n.CategoryId == id)
                       .FirstOrDefaultAsync();

                return (T)(object)categories;
            }
            else if (typeof(T) == typeof(Product))
            {
                var products = await _dbcontext.Products
                       .Where(n => n.ProductId == id)
                       .FirstOrDefaultAsync();

                return (T)(object)products;
            }

            return null;
        }

       

        public async Task<int> Create(T entity)
        {
            _dbSet.Add(entity);
            await _dbcontext.SaveChangesAsync();
            return 1;
        }

        public async Task<int> Update(int id, T entity)
        {
            var existingEntity = await GetById(id);
            if (existingEntity == null)
                return 0;

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
            return 1;

        }

        public async Task<bool> Delete(int id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

