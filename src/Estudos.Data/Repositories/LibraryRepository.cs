using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces;
using Estudos.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Estudos.Data.Repositories
{
    public class LibraryRepository : CrudRepository<Library>, ILibraryRepository
    {
        private readonly DbContext _context;

        public LibraryRepository(DbContext context) : base(context) 
        {
            _context = context;
        }
    }
}
