namespace Estudos.Domain.Interfaces
{
    public interface ICrudRepository<TEntity>
    {
        bool Add(TEntity obj);
        bool Update(TEntity obj);
        bool Delete(TEntity entity);
    }
}
