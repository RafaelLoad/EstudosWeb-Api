using Estudos.Application.Interfaces;
using Estudos.Domain.Entities;
using Estudos.Domain.ViewModels;
using Estudos.Services.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace Estudos.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IUsuarioService _usuarios;
        private readonly IJwtBearerTokenService _jwtBearerTokenService;
        private readonly ICachingService _cachingService;
        public LoginController
        (
            IUsuarioService usuarios,
            IJwtBearerTokenService jwtBearerTokenService,
            ILogger<LoginController> logger,
            ICachingService cachingService
        )
        {
            _usuarios = usuarios;
            _jwtBearerTokenService = jwtBearerTokenService;
            _logger = logger;
            _cachingService = cachingService;
        }

        [HttpPost("Autenticar")]
        public async Task<IActionResult> Usuario(LoginViewModel login)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var cacheToken = await _cachingService.GetAsync(login.Usuario.ToString());

                if (!string.IsNullOrEmpty(cacheToken)) 
                    return Ok(cacheToken);

                var usuario = await _usuarios.Buscar(login);

                if (usuario is null)
                    return NotFound("Usuário não encontrado");


                var token = _jwtBearerTokenService.CriarToken(ClaimsList(usuario));


                _logger.LogError("Erro na autenticação da controller: ");
                await _cachingService.SetAsync(usuario.Usuario.ToString(), JsonConvert.SerializeObject(token));

                return Ok(token);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro na autenticação da controller: ", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro no servidor");
            }
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar(LoginViewModel login)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var usuario = await _usuarios.Buscar(login);

            return Ok(_jwtBearerTokenService.CriarToken(ClaimsList(usuario)));
        }

        private List<Claim> ClaimsList(User usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Usuario.ToString()),
                new Claim(ClaimTypes.NameIdentifier, usuario.Usuario),
                new Claim(ClaimTypes.Role, usuario.Perfil.ToString())
            };

            return claims;
        }
    }
}
