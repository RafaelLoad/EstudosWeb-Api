using Estudos.Domain.DTO;
using Estudos.Domain.Entities;

namespace Estudos.Application.Interfaces
{
    public interface IClienteService
    {
        Task<Tuple<bool, string>> Adicionar(ClienteInputDTO cliente);
        Task<IEnumerable<Cliente>> BuscarTodos(string nome, string cpf, string email);
        Task<Cliente> BuscarPorId(int id);
        Task<Tuple<bool, string>> Atualizar(Cliente cliente);
        Task<Tuple<bool, string>>  Deletar(int id, int? idEndereco, int? idContato);
        Task<ViaCepResponse> ConsultarCep(string cep);
        Task<IEnumerable<Endereco>> BuscarTodosEnderecos();
    }
}
