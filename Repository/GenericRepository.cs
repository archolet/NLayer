using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        // readonly ya tanımlanırken değer atayabilirsin yada constrocturda değer atayabilirsin başka yerde değer atayamazsın
        protected readonly AppDbContext _appDbContext; 
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext appDbContext )
        {
            _appDbContext = appDbContext;
            _dbSet = appDbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
           return _dbSet.AsNoTracking().AsQueryable();
            //asnotracking çekmiş olduğu dataları memorye almasın 10000 data çekersen hepsini anlık izler. sonuçta getall yapıyorsun.
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
           return _dbSet.Where(predicate);
        }
    }
}
