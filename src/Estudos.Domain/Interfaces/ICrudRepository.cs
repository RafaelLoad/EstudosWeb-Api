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
        bool Add(TEntity obj);
        bool Update(TEntity obj);
        bool Delete(TEntity entity);
    }
}
