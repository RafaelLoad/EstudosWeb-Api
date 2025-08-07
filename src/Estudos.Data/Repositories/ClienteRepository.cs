using Dapper;
using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Estudos.Data.Repositories
{
    public class ClienteRepository : CrudRepository<Cliente>, IClienteRepository
    {
        private readonly IDbConnection _dbConnectionDapper;
        private readonly DbSet<Cliente> _cliente;

        public ClienteRepository(DbContext context, IDbConnection connection)/* : base(context)*/
        {
            _dbConnectionDapper = connection;
            _cliente = context.Set<Cliente>();
        }
        public Cliente BuscarPorId(int id)
        {
            return _cliente
                .Include(c => c.Endereco)
                .Include(c => c.Contato)
                .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Cliente> BuscarTodos()
        {
            return  _cliente.Include(c => c.Endereco).Include(c => c.Contato).ToList();
        }

        public IEnumerable<Endereco> BuscarTodosEnderecos()
        {
            var queryCommand = @"SELECT * FROM Endereco";
            return  _dbConnectionDapper.Query<Endereco>(queryCommand);
        }
    }
}
