using Estudos.Domain.Entities;
using Estudos.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.Domain.Interfaces
{
    public interface ICrudRepository<TEntity>
    {
        Task<bool> Add(TEntity obj);
        Task<TEntity> Alter(TEntity obj);
        Task<TEntity> GetById(int obj);
        Task<bool> Delete(int obj);
    }
}
