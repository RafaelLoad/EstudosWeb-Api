using Estudos.Application.Interfaces;
using Estudos.Data.Context;
using Estudos.Domain.Entities;
using Estudos.Domain.Enum;
using Estudos.Domain.Interfaces;
using Estudos.Domain.ViewModels;

namespace Estudos.Application.Login
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuario;
        private readonly AppDbContext _context;

        public UsuarioService
        (
            IUsuarioRepository usuario,
            AppDbContext context
        )
        {
            _usuario = usuario;
            _context = context;
        }
        public async Task<User> Buscar(LoginDTO login)
        {
            var usuario = "Rafa";
            var senha = "8979";

            if(login.Usuario != usuario || login.Senha != senha)
            {
                return null;
            }

            var user = new User
            {
                Id = 1,
                Usuario = "Rafa",
                Password = "8979",
                Perfil = EnumPerfil.Usuario
            };
            //var usuario = _usuario.Get(login.Usuario);

            //if (usuario is null)
            //{
            //    var novoUsuario = new User
            //    {
            //        Usuario = login.Usuario,
            //        Password = login.Senha
            //    };
            //    _context.Usuario.Add(novoUsuario);
            //    await _context.SaveChangesAsync();

            //    return novoUsuario;
            //}

            return user;
        }
    }
}
