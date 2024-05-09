using Estudos.Domain.Entities;
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
            _dbSet.AddAsync(obj);
            return true;
        }

        public async Task<bool> Update(TEntity obj)
        {
            _dbSet.Update(obj);
            return true;
        }

        public async Task<bool> Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            return true;
        }

    }
}
