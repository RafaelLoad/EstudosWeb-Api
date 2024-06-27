using Estudos.Data.Mappings;
using Estudos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using System;

namespace Estudos.Data.Context
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        {
        }

    
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<User> Usuario { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);

            //faz a mesma coisa que em cima
            //modelBuilder.ApplyConfiguration(new ClienteMap());
            //modelBuilder.ApplyConfiguration(new ContatoMap());
            //modelBuilder.ApplyConfiguration(new EnderecoMap());
            //modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
    }
}