using CollegeApp.Data;
using Microsoft.EntityFrameworkCore;

namespace CollegeApp.Data.Repository
{
    public class CollegeRepository<T> : ICollegeRepository<T> where T : class
    {
        private readonly CollageDBContext _dbcontext;
        private readonly DbSet<T> _dbSet;

        public CollegeRepository(CollageDBContext dbcontext)
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
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetByName(string name)
        {
            if (typeof(T) == typeof(Student))
            {
                var students = await _dbcontext.Students
                       .Where(n => n.name == name)
                       .FirstOrDefaultAsync();

                return (T)(object)students;
            }
            else if (typeof(T) == typeof(Course))
            {
                var courses = await _dbcontext.Courses
                       .Where(n => n.CourseName == name)
                       .FirstOrDefaultAsync();

                return (T)(object)courses;
            }

            return null;
        }

        public async Task<int> Create(T entity)
        {
            _dbSet.Add(entity);
            await _dbcontext.SaveChangesAsync();
            return 1;
        }

        public async Task<int> Update(T entity)
        {
            _dbSet.Update(entity);
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