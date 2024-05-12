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
            => Ok(await _clienteService.Add(cliente));

        [HttpPut("Atualizar/{id}")]
        public async Task<IActionResult> Update(Cliente cliente, int id)
        {
            return Ok(await _clienteService.Update(cliente, id));
        }

        [HttpGet("BuscarPorId/{id}")]
        public async Task<IActionResult> GetById(int id, bool getDependencies = false)
        {
            return Ok(await _clienteService.GetById(id, getDependencies));
        }

        [HttpGet("BuscarTodos")]
        public async Task<IActionResult> GetAll(string? nome, string? cpf, string? email)
        {
            return Ok(await _clienteService.GetAll(nome, cpf, email));
        }

        [HttpDelete("Remover/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _clienteService.Delete(id));
        }
    }
}
