using Estudos.Application.Interfaces;
using Estudos.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Estudos.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("Adicionar")]
        public async Task<IActionResult> Add(User usuario)
        {
            return Ok( await _usuarioService.Add(usuario));
        }

        [HttpGet("BuscarTodos")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _usuarioService.GetAll());
        }
    }
}
