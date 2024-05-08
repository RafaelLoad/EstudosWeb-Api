using Estudos.Domain.Entities;

namespace Estudos.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> Add(Cliente cliente);
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente> Atualizar(Cliente cliente);
        Task<bool> Delete(int id);
    }
}
