using Estudos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.Application.Interfaces
{
    public interface IClienteService
    {
        Task<Cliente> Add(Cliente cliente);
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente> Atualizar(Cliente cliente);
        Task<bool> Delete(int id);
    }
}
