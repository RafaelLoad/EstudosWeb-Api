using Estudos.Domain.Enum;

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
