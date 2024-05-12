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

        public bool Add(TEntity obj)
        {
            _dbSet.Add(obj);
            return true;
        }

        public bool Update(TEntity obj)
        {
            _dbSet.Update(obj);
            return true;
        }

        public bool Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            return true;
        }

    }
}
