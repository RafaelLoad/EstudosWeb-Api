
using Estudos.Data.Repositories;
using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Estudos.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<Cliente> _cliente;

        public ClienteRepository(DbContext context)
        {
            _dbContext = context;
            _cliente = context.Set<Cliente>();
        }
        public async Task<Cliente> GetById(int id)
        {
            return await _cliente.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Cliente> Add(Cliente cliente)
        {
            _cliente.AddAsync(cliente);
            await _dbContext.SaveChangesAsync(); 
            
            return cliente;
        }

        public async Task<Cliente> Atualizar(Cliente cliente)
        {
            _dbContext.Update(cliente);
            await _dbContext.SaveChangesAsync();

            return await  GetById(cliente.Id);
        }

        public async Task<bool> Delete(int id)
        {
            var cliente = await GetById(id);
            if (cliente != null)
            {
                _dbContext.Remove(cliente);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _cliente.Include(c => c.Endereco).Include(c => c.Contato).ToListAsync();
        }
    }
}

