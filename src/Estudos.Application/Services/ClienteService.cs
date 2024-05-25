using Estudos.Application.Interfaces;
using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Estudos.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IViaCepService _viaCepService;
        private readonly DbContext _context;

        public ClienteService(IClienteRepository clienteRepository, IViaCepService viaCepService, DbContext context)
        {
            _clienteRepository = clienteRepository;
            _viaCepService = viaCepService;
            _context = context;
        }

        public async Task<Tuple<bool, string>> Adicionar(Cliente cliente)
        {
            var dados = await ViaCep(cliente.Endereco.CEP);

            if (dados.CepValidacao())
                return new Tuple<bool, string>(false, "Cep Invalido");


            var resultado = _clienteRepository.Adicionar(cliente);
            _context.SaveChanges();
            return new Tuple<bool, string>(true, "Cliente adicionado!");
        }

        public async Task<Cliente> BuscarPorId(int id, bool getDependencies = false)
            => _clienteRepository.BuscarPorId(id, getDependencies);

        public async Task<IEnumerable<Cliente>> BuscarTodos(string? nome, string? cpf, string? email)
        {
            return _clienteRepository.BuscarTodos()
                .Where(c =>
                    (string.IsNullOrEmpty(nome) || c.Nome.Contains(nome)) &&
                    (string.IsNullOrEmpty(email) || c.Email.Contains(email)) &&
                    (string.IsNullOrEmpty(cpf) || c.CPF == cpf))
                .ToList();
        }

        public async Task<Tuple<bool, string>> Atualizar(Cliente cliente, int id)
        {
            var dbResult = await BuscarPorId(id, true);
            if (dbResult == null)
                return new Tuple<bool, string>(false, "Cliente não existente");

            dbResult.Nome = cliente.Nome;
            dbResult.Email = cliente.Email;
            dbResult.CPF = cliente.CPF;
            dbResult.RG = cliente.RG;
            dbResult.Endereco.Tipo = cliente.Endereco.Tipo;
            dbResult.Endereco.CEP = cliente.Endereco.CEP;
            dbResult.Endereco.Logradouro = cliente.Endereco.Logradouro;
            dbResult.Endereco.Numero = cliente.Endereco.Numero;
            dbResult.Endereco.Bairro = cliente.Endereco.Bairro;
            dbResult.Endereco.Complemento = cliente.Endereco.Complemento;
            dbResult.Endereco.Cidade = cliente.Endereco.Cidade;
            dbResult.Endereco.Estado = cliente.Endereco.Estado;
            dbResult.Endereco.Referencia = cliente.Endereco.Referencia;

            foreach (var contato in cliente.Contato)
            {
                var dbContato = dbResult.Contato.FirstOrDefault(c => c.Id == contato.Id);
                if (dbContato != null)
                {
                    dbContato.Tipo = contato.Tipo;
                    dbContato.DDD = contato.DDD;
                    dbContato.Telefone = contato.Telefone;
                }
            }

            _clienteRepository.Atualizar(dbResult);
            _context.SaveChanges();

            return new Tuple<bool, string>(true, "Atualizado com Sucesso!");
        }

        public async Task<Tuple<bool, string>> Deletar(int id, int? idEndereco, int? idContato)
        {
            var cliente = _clienteRepository.BuscarPorId(id, true);

            if (cliente is null)
             return new Tuple<bool, string>(false, "Cliente não existente");

            if (idEndereco.HasValue)
            {
                var endereco = cliente.Endereco;
                if (endereco.Id.Equals(idEndereco))
                {
                    _context.Remove(endereco);
                    _context.SaveChanges();
                    return new Tuple<bool, string>(true, "Endereço removido com sucesso!");
                }
                else
                {
                    return new Tuple<bool, string>(false, "Endereço não existente");
                }
            }

            if (idContato.HasValue)
            {
                var contato = cliente.Contato.FirstOrDefault(x => x.Id == idContato);
                if (contato != null)
                {
                    _context.Remove(contato);
                    _context.SaveChanges();
                    return new Tuple<bool, string>(true, "Contato removido com sucesso!");
                }
                else
                {
                    return new Tuple<bool, string>(false, "Contato não existente");
                }
            }

            _clienteRepository.Delete(cliente);
            _context.SaveChanges();

            return new Tuple<bool, string>(true, "Cliente removido com sucesso!");
        }

        private async Task<ViaCepResponse> ViaCep(string cep)
            => await _viaCepService.Get(cep);

        public async Task<ViaCepResponse> ConsultarCep(string cep)
        {
            return await ViaCep(cep);
        }
    }
}
