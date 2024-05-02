using Estudos.Domain.Entities;
using Estudos.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Estudos.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public LoginController()
        {
                
        }


        [HttpGet("Login")]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if(!ModelState.IsValid)
            return BadRequest(login);

            return Ok();
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Create(UserViewModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest(user);

            return Ok();
        }
    }
}
