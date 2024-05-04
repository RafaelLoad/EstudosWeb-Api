using Estudos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<User> Add(User user);
        Task<IEnumerable<User>> GetAll();
    }
}
