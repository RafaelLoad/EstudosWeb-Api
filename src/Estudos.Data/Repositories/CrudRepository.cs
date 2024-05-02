using Estudos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Estudos.Data.Repositories
{
    public class CrudRepository<TEntity> : ICrudRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public CrudRepository
        (
            DbContext context
        )
        {
            _context = context;
            _dbSet = context.Set<TEntity>();

        }

        public async Task<bool> Add(TEntity obj)
        {
            _dbSet.Add(obj);
            return true;
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> Alter(TEntity obj)
        {
            _dbSet.Update(obj);
            return obj; 
        }

        public async Task<bool> Delete(int id)
        {
            var entity =  await GetById(id);
            _dbSet.Remove(entity);
            return true;
        }
    }
}
