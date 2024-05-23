using Estudos.Domain.Entities;

namespace Estudos.Application.Interfaces
{
    public interface IClienteService
    {
        Task<bool> Adicionar(Cliente cliente);
        Task<IEnumerable<Cliente>> BuscarTodos(string? nome, string? cpf, string? email);
        Task<Cliente> BuscarPorId(int id, bool getDependencies = false);
        Task<Tuple<bool, string>> Atualizar(Cliente cliente, int id);
        Task<Tuple<bool, string>>  Deletar(int id, int? idEndereco, int? idContato);
    }
}
