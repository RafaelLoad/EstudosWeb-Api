using Estudos.Application.Interfaces;
using Estudos.Domain.Entities;
using Estudos.Domain.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Estudos.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
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
        public async Task<IActionResult> Adicionar(Cliente cliente)
            => Ok(await _clienteService.Adicionar(cliente));

        [HttpPut("Atualizar/{id}")]
        public async Task<IActionResult> Atualizar(Cliente cliente, int id)
        {
            return Ok(await _clienteService.Atualizar(cliente, id));
        }

        [HttpGet("BuscarPorId/{id}")]
        public async Task<IActionResult> BuscarPorId(int id, bool getDependencies = false)
        {
            return Ok(await _clienteService.BuscarPorId(id, getDependencies));
        }

        [HttpGet("BuscarTodos")]
        public async Task<IActionResult> BuscarTodos(string? nome, string? cpf, string? email)
        {
            //return Ok(await _clienteService.BuscarTodos(nome, cpf, email));
            return Ok(new Cliente()
            {
                Id = 10
            });
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

        [HttpGet("BuscarTodos/Contatos")]
        public async Task<IActionResult> TodosContatos()
           => Ok(await _clienteService.BuscarTodosContatos());

    }
}
