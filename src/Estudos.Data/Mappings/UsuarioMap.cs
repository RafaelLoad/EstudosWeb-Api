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
    internal class UsuarioMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.T("usuario");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);

            builder.Property(x => x.Name);
            builder.Property(x => x.Sobrenome);
            builder.Property(x => x.Email);
        }
    }
}