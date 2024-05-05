using Estudos.Application.Interfaces;
using Estudos.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Estudos.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        IClienteService _clienteService;
        public ClienteController(IClienteService ClienteService)
        {
            _clienteService = ClienteService;
        }

        [HttpPost("Adicionar")]
        public async Task<IActionResult> Add(Cliente cliente)
        {
            return Ok( await _clienteService.Add(cliente));
        }

        [HttpPut("Atualizar")]
        public async Task<IActionResult> Update(Cliente cliente)
        {
            return Ok(await _clienteService.Atualizar(cliente));
        }

        [HttpGet("BuscarTodos")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _clienteService.GetAll());
        }

        [HttpDelete("Remover")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _clienteService.Delete(id));
        }
    }
}
