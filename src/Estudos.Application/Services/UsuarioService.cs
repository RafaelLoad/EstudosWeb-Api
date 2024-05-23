using Estudos.Application.Interfaces;
using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces;
using Estudos.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Estudos.Application.Login
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuario;
        private readonly DbContext _context;

        public UsuarioService
        (
            IUsuarioRepository usuario,
            DbContext context
        )
        {
            _usuario = usuario;
            _context = context;
        }
        public async Task<User> Buscar(LoginViewModel login)
        {
            var user = _usuario.Get(login.Usuario);

            if (user is null)
            {
                var novoUsuario = new User
                {
                    Usuario = login.Usuario,
                    Password = login.Senha
                };
                _usuario.Adicionar(novoUsuario);
                _context.SaveChanges();

                return novoUsuario;

            }

            return user;
        }
    }
}
