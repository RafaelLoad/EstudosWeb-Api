using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estudos.Domain.Entities;

namespace Estudos.Data.Mappings
{
    internal class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("cliente");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("nome");

            builder.Property(x => x.Email)
                .HasColumnName("email");

            builder.Property(x => x.CPF)
                .HasColumnName("cpf");

            builder.Property(x => x.RG)
                .HasColumnName("rg");

            builder.HasOne(x => x.Endereco)
               .WithOne()
               .HasForeignKey<Endereco>(x => x.Id);

            builder.HasMany(x => x.Contato)
              .WithOne()
              .HasForeignKey(x => x.IdCliente);
        }
    }
}