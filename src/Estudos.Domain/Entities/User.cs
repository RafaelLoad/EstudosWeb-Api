using Estudos.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public EnumPerfil Perfil { get; set; } = EnumPerfil.Usuario;
    }
}
