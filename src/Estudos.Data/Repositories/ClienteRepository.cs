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
        public async Task<Cliente> GetById(int id, bool getDependencies = false)
        {
            if (getDependencies)
                return await _cliente.Include(c => c.Endereco).Include(c => c.Contato).FirstOrDefaultAsync(x => x.Id == id);

            return await _cliente.FindAsync(id);
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _cliente.Include(c => c.Endereco).Include(c => c.Contato).ToListAsync();
        }

    }
}

