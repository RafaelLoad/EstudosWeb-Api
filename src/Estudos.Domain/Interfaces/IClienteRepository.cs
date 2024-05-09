using Estudos.Domain.Entities;

namespace Estudos.Domain.Interfaces
{
    public interface IClienteRepository : ICrudRepository<Cliente>
    {
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente> GetById(int id, bool getDependencies = false);
    }
}
