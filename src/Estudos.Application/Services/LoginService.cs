using Estudos.Application.Interfaces;
using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces;
using Estudos.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Estudos.Application.Login
{
    public class LoginService : ILoginService
    {
        private readonly ILibraryRepository _produtoRepository;
        private readonly DbContext _context;
        private readonly ILogger<LoginService> _logger;
        public LoginService
        (
            DbContext context,
            ILogger<LoginService> logger
        )
        {
        }

        public Task<bool> Add(LibraryViewModel obj)
        {
            throw new NotImplementedException();
        }

        public Task<User> Alter(LibraryViewModel obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(LibraryViewModel obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll(LibraryViewModel obj)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
