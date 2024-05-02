using Estudos.Application.Interfaces;
using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces;
using Estudos.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Estudos.Application.Produto
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository _produtoRepository;
        private readonly DbContext _context;
        private readonly ILogger<LibraryService> _logger;
        public LibraryService
        (
            ILibraryRepository produtoRepository,
            DbContext context,
            ILogger<LibraryService> logger
        )
        {
            _produtoRepository = produtoRepository;
            _context = context;
            _logger = logger;
        }

        public Task<bool> Add(LibraryViewModel obj)
        {
            throw new NotImplementedException();
        }

        public Task<Library> Alter(LibraryViewModel obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(LibraryViewModel obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<Library>> GetAll(LibraryViewModel obj)
        {
            throw new NotImplementedException();
        }

        public Task<Library> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
