using Estudos.Application.Interfaces;
using Estudos.Data.Context;
using Estudos.Domain.DTO;
using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace Estudos.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly ILogger<ClienteService> _logger;
        private readonly IClienteRepository _clienteRepository;
        private readonly IViaCepService _viaCepService;
        private readonly AppDbContext _context;

        public ClienteService
        (
            ILogger<ClienteService> logger,
            IClienteRepository clienteRepository,
            IViaCepService viaCepService,
            AppDbContext context
        )
        {
            _logger = logger;
            _clienteRepository = clienteRepository;
            _viaCepService = viaCepService;
            _context = context;
        }


        public async Task<Tuple<bool, string>> Adicionar(ClienteInputDTO clienteDto)
        {
            var dados = await ViaCep(clienteDto.Endereco.CEP);

            if (dados.CepValidacao())
                return new Tuple<bool, string>(false, "Cep Inválido");

            var cliente = new Cliente
            {
                Nome = clienteDto.Nome,
                Email = clienteDto.Email,
                CPF = clienteDto.CPF,
                RG = clienteDto.RG,
                Endereco = new Endereco
                {
                    Tipo = clienteDto.Endereco.Tipo,
                    CEP = clienteDto.Endereco.CEP,
                    Logradouro = clienteDto.Endereco.Logradouro,
                    Numero = clienteDto.Endereco.Numero,
                    Bairro = clienteDto.Endereco.Bairro,
                    Complemento = clienteDto.Endereco.Complemento,
                    Cidade = clienteDto.Endereco.Cidade,
                    Estado = clienteDto.Endereco.Estado,
                    Referencia = clienteDto.Endereco.Referencia
                },
                Contato = clienteDto.Contato.Select(c => new Contato
                {
                    Tipo = c.Tipo,
                    DDD = c.DDD,
                    Telefone = c.Telefone
                }).ToList()
            };

            _context.Cliente.Add(cliente);
            _context.SaveChanges();
            return new Tuple<bool, string>(true, "Cliente adicionado!");
        }

        public async Task<Cliente> BuscarPorId(int id)
            => _clienteRepository.BuscarPorId(id);

        public async Task<IEnumerable<Cliente>> BuscarTodos(string nome, string cpf, string email)
        {
            return await _context.Cliente
                .Where(c =>
                    (string.IsNullOrEmpty(nome) || c.Nome.Contains(nome)) &&
                    (string.IsNullOrEmpty(email) || c.Email.Contains(email)) &&
                    (string.IsNullOrEmpty(cpf) || c.CPF == cpf))
                .ToListAsync();
        }

        public async Task<Tuple<bool, string>> Atualizar(Cliente cliente)
        {
            var dbResult = await BuscarPorId(cliente.Id);
            if (dbResult is null)
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

            _context.Cliente.Update(dbResult);
            _context.SaveChanges();

            return new Tuple<bool, string>(true, "Atualizado com Sucesso!");
        }


        public async Task<Tuple<bool, string>> Deletar(int id, int? idEndereco, int? idContato)
        {
            var cliente = _clienteRepository.BuscarPorId(id);

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
                if (contato is not null)
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

            _context.Cliente.Remove(cliente);
            _context.SaveChanges();

            return new Tuple<bool, string>(true, "Cliente removido com sucesso!");
        }

        private async Task<ViaCepResponse> ViaCep(string cep)
        {
            try
            {
                return await _viaCepService.Buscar(TrataCep(cep));
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao chamar serviçod de Cep : ", ex.Message);
                return new ViaCepResponse (false, "Erro inesperado ao chamar serviço de CEP.");
            }
        }
        public async Task<ViaCepResponse> ConsultarCep(string cep)
        => await ViaCep(cep);

        private string TrataCep(string cep)
             => cep?.Replace(".", "").Replace("-", "");

        public async Task<IEnumerable<Endereco>> BuscarTodosEnderecos()
        =>  _clienteRepository.BuscarTodosEnderecos();
    }
}
