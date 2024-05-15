using Estudos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estudos.Data.Mappings
{
    internal class ContatoMap : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("contato");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(x => x.Tipo)
                .HasColumnName("tipo");

            builder.Property(x => x.DDD)
                .HasColumnName("ddd");

            builder.Property(x => x.Telefone)
                .HasColumnName("telefone");
        }
    }
}
