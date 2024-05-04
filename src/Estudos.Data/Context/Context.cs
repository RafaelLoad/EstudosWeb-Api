using Estudos.Data.Mappings;
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

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
    }
}
