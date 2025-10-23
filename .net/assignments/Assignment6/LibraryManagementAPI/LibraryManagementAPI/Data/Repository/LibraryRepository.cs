using LibraryManagementAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Data.Repository
{
    public class LibraryRepository<T> : ILibraryRepository<T> where T : class
    {
        private readonly LibraryDbContext _dbcontext;
        private readonly DbSet<T> _dbSet;

        public LibraryRepository(LibraryDbContext dbcontext)
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
            if (typeof(T) == typeof(Author))
            {
                var authors = await _dbcontext.Authors
                       .Where(n => n.AuthorID == id)
                       .FirstOrDefaultAsync();

                return (T)(object)authors;
            }
            else if (typeof(T) == typeof(Book))
            {
                var books = await _dbcontext.Books
                       .Where(n => n.BookId == id)
                       .FirstOrDefaultAsync();

                return (T)(object)books;
            }

            return null;
        }

        public async Task<T> GetByName(string name)
        {
            if (typeof(T) == typeof(Author))
            {
                var authors = await _dbcontext.Authors
                       .Where(n => n.Name == name)
                       .FirstOrDefaultAsync();

                return (T)(object)authors;
            }
            else if (typeof(T) == typeof(Book))
            {
                var books = await _dbcontext.Books
                       .Where(n => n.Title == name)
                       .FirstOrDefaultAsync();

                return (T)(object)books;
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
            var entity = await _dbSet.FindAsync(id);
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
