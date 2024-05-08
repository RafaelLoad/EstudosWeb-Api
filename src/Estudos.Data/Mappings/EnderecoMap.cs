using Estudos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estudos.Data.Mappings
{
    internal class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(x => x.Tipo)
                .HasColumnName("tipo");

            builder.Property(x => x.CEP)
                .HasColumnName("cep");

            builder.Property(x => x.Logradouro)
                .HasColumnName("logradouro");

            builder.Property(x => x.Numero)
                .HasColumnName("numero");

            builder.Property(x => x.Bairro)
                .HasColumnName("bairro");

            builder.Property(x => x.Complemento)
                .HasColumnName("complemento");

            builder.Property(x => x.Cidade)
                .HasColumnName("cidade");

            builder.Property(x => x.Estado)
                .HasColumnName("estado");

            builder.Property(x => x.Referencia)
                .HasColumnName("referencia");
        }
    }
}
