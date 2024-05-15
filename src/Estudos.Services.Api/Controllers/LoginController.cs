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
        private readonly IUsuarioService _users;
        private readonly IJwtBearerTokenService _jwtBearerTokenService;
        public LoginController
        (
            IUsuarioService users,
            IJwtBearerTokenService jwtBearerTokenService
        )
        {
            _users = users;
            _jwtBearerTokenService = jwtBearerTokenService;
        }

        [HttpPost("Usuario")]
        public async Task<IActionResult> Usuario(LoginViewModel login)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await _users.Get(login);
            

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Usuario.ToString()),
                new Claim(ClaimTypes.NameIdentifier,  user.Usuario)
            };

            return Ok(_jwtBearerTokenService.CreateToken(claims));
        }
    }
}
