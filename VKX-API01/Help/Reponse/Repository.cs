
using Microsoft.EntityFrameworkCore;
using VKX_API01.Application;

namespace VKX_API01.Help.Reponse
{
    public class Repository : IReponsitory
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync<T>() where T : class
        {
            var dbSet = _context.Set<T>();
            return await dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync<T>(object id) where T : class
        {
            var dbSet = _context.Set<T>();
            return await dbSet.FindAsync(id);
        }

        public async Task<T?> AddAsync<T>(T entity) where T : class
        {
            var dbSet = _context.Set<T>();
            var addedEntity = await dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return addedEntity.Entity;
        }

        public async Task<bool> UpdateAsync<T>(object id, T entity) where T : class
        {
            var dbSet = _context.Set<T>();
            var existingEntity = await dbSet.FindAsync(id);
            if (existingEntity == null)
                return false;

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync<T>(object id) where T : class
        {
            var dbSet = _context.Set<T>();
            var entity = await dbSet.FindAsync(id);
            if (entity == null)
                return false;

            dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return _context.Set<T>().AsQueryable();
        }
    }

}
