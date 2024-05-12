using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Estudos.Data.Repositories
{
    public class ClienteRepository : CrudRepository<Cliente>, IClienteRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<Cliente> _cliente;

        public ClienteRepository(DbContext context) : base(context)
        {
            _dbContext = context;
            _cliente = context.Set<Cliente>();
        }
        public Cliente GetById(int id, bool getDependencies = false)
        {
            if (getDependencies)
                return  _cliente.Include(c => c.Endereco).Include(c => c.Contato).FirstOrDefault(x => x.Id == id);

            return  _cliente.Find(id);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return  _cliente.Include(c => c.Endereco).Include(c => c.Contato).ToList();
        }

    }
}

