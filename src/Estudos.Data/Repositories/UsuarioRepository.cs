using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Estudos.Data.Repositories
{
    public class UsuarioRepository : CrudRepository<User>, IUsuarioRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<User> _user;

        //public UsuarioRepository(DbContext context) : base(context)
        //{
        //    _dbContext = context;
        //    _user = context.Set<User>();
        //}

        public User Get(string usuario)
            => _user.FirstOrDefault(x => x.Usuario == usuario);
    }
}

