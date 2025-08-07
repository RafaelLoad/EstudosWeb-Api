using Estudos.Application.Login;
using Estudos.Data.Context;
using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces;
using Estudos.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Estudos.Aplication.Testes.Services
{
    public class UsuarioServiceTeste
    {
        private readonly UsuarioService usuarioService;

        public UsuarioServiceTeste()
        {
            usuarioService = new UsuarioService(new Mock<IUsuarioRepository>().Object, null);  
        }

        [Fact]
        public async void Buscar_GetUser()
        {

           var loginViewModel = new LoginDTO { Usuario = "Rafa", Senha = "Rafa" };
           var expectedUser = new User { Usuario = "Rafa", Password = "Rafa" };

            var result = await usuarioService.Buscar(loginViewModel);

            Assert.NotNull(result);
            Assert.Equal(expectedUser.Usuario, result.Usuario);
            Assert.Equal(expectedUser.Password, result.Password);

        }
    }
}
