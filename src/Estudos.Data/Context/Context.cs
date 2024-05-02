using Estudos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Estudos.Data.Context
{

    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) :
            base(options)
        {
        }

        public DbSet<Library> Library { get; set; }

    }
}
