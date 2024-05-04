using Estudos.Application.Interfaces;
using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces;


namespace Estudos.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<User> Add(User usuario)
        {
            var retorno = await _usuarioRepository.Add(usuario);
            return retorno;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var retorno = await _usuarioRepository.GetAll();
            return retorno;
        }
    }
}
