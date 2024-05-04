using Estudos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<User> Add(User usuario);
        Task<IEnumerable<User>> GetAll();
    }
}
