using Estudos.Application.Interfaces;
using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces;


namespace Estudos.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository usuarioRepository)
        {
            _clienteRepository = usuarioRepository;
        }
        public async Task<Cliente> Add(Cliente cliente)
        {
            var retorno = await _clienteRepository.Add(cliente);
            return retorno;
        }


        public async Task<IEnumerable<Cliente>> GetAll()
        {
            var retorno = await _clienteRepository.GetAll();
            return retorno;
        }

        public Task<Cliente> Atualizar(Cliente cliente)
        {
            var retorno = _clienteRepository.Atualizar(cliente);
            return retorno;
        }
        public Task<bool> Delete(int id)
        {
            var retorno = _clienteRepository.Delete(id);
            return retorno;
        }
    }
}
