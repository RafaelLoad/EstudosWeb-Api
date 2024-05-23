using Estudos.Application.Interfaces;
using Estudos.Domain.Entities;
using Estudos.Domain.ViewModels;
using Estudos.Services.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace Estudos.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IUsuarioService _usuarios;
        private readonly IJwtBearerTokenService _jwtBearerTokenService;
        public LoginController
        (
            IUsuarioService usuarios,
            IJwtBearerTokenService jwtBearerTokenService
        )
        {
            _usuarios = usuarios;
            _jwtBearerTokenService = jwtBearerTokenService;
        }

        [HttpPost("Autenticar")]
        public async Task<IActionResult> Usuario(LoginViewModel login)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var usuario = await _usuarios.Buscar(login);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Usuario.ToString()),
                new Claim(ClaimTypes.NameIdentifier, usuario.Usuario)
            };


            return Ok(_jwtBearerTokenService.CriarToken(claims));
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar(LoginViewModel login)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var usuario = await _usuarios.Buscar(login);


            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Usuario.ToString()),
                new Claim(ClaimTypes.NameIdentifier, usuario.Usuario)
            };


            return Ok(_jwtBearerTokenService.CriarToken(claims));
        }
    }
}
