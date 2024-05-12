using Estudos.Domain.Entities;

namespace Estudos.Domain.Interfaces
{
    public interface IClienteRepository : ICrudRepository<Cliente>
    {
        IEnumerable<Cliente> GetAll();
        Cliente GetById(int id, bool getDependencies = false);
    }
}
