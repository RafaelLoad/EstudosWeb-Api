using Estudos.Domain.Entities;

namespace Estudos.Domain.Interfaces
{
    public interface IClienteRepository : ICrudRepository<Cliente>
    {
        IEnumerable<Cliente> BuscarTodos();
        Cliente BuscarPorId(int id, bool getDependencies = false);
    }
}
