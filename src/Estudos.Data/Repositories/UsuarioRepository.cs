
using Estudos.Data.Repositories;
using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Estudos.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<User> _users;

        public UsuarioRepository(DbContext context)
        {
            _dbContext = context;
            _users = context.Set<User>();
        }
        public async Task<User> Add(User user)
        {
            _users.AddAsync(user);
            await _dbContext.SaveChangesAsync(); 
            
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _users.ToListAsync();
        }
    }
}

