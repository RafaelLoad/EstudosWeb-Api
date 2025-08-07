using Estudos.Application.Interfaces;
using Estudos.Domain.DTO;
using Estudos.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Estudos.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [AllowAnonymous]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        public ClienteController
        (
            IClienteService ClienteService
        )
        {
            _clienteService = ClienteService;
        }

        [HttpPost("Adicionar")]
        public async Task<IActionResult> Adicionar(ClienteInputDTO cliente)
            => Ok(await _clienteService.Adicionar(cliente));

        [HttpPut("Atualizar")]
        public async Task<IActionResult> Atualizar(Cliente cliente)
        {
            return Ok(await _clienteService.Atualizar(cliente));
        }

        [HttpGet("BuscarPorId/{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            return Ok(await _clienteService.BuscarPorId(id));
        }

        [HttpGet("BuscarTodos")]
        public async Task<IActionResult> BuscarTodos(string? nome, string? cpf, string? email)
        {
            return Ok(await _clienteService.BuscarTodos(nome, cpf, email));
        }

        [HttpGet("Cep/{cep}")]
        public async Task<IActionResult> Cep(string cep)
            => Ok(await _clienteService.ConsultarCep(cep));

        [Authorize(Roles = "Administrador")]
        [HttpDelete("Remover/{id}")]
        public async Task<IActionResult> Deletar(int id, int? idEndereco, int? idContato)
        {
            await _clienteService.Deletar(id, idEndereco, idContato);
            return NoContent();
        }

        [HttpGet("BuscarTodos/Enderecos")]
        public async Task<IActionResult> TodosEnderecos()
           => Ok(await _clienteService.BuscarTodosEnderecos());
    }
}
