using Estudos.Application.Interfaces;
using Estudos.Domain.Entities;
using Estudos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Estudos.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly DbContext _context;

        public ClienteService
        (
            IClienteRepository usuarioRepository,
            DbContext context
        )
        {
            _clienteRepository = usuarioRepository;
            _context = context;
        }

        public async Task<bool> Add(Cliente cliente)
        {
             var result =  _clienteRepository.Add(cliente);
            _context.SaveChanges();
            return result;

        }

        public async Task<Cliente> GetById(int id, bool getDependencies = false)
        {
            return  _clienteRepository.GetById(id, getDependencies);
        }

        public async Task<IEnumerable<Cliente>> GetAll(string? nome, string? cpf, string? email)
        {
            return _clienteRepository.GetAll()
                .Where(c =>
                    (string.IsNullOrEmpty(nome) || c.Nome.Contains(nome)) &&
                    (string.IsNullOrEmpty(email) || c.Email.Contains(email)) &&
                    (string.IsNullOrEmpty(cpf) || c.CPF == cpf))
                .ToList();
        }

        public async Task<Tuple<bool, string>> Update(Cliente cliente, int id)
        {
            var dbResult = await GetById(id, true);
            if (dbResult == null)
            {
                return new Tuple<bool, string>(false, "Cliente não existente");
            }

            dbResult.IdEndereco = cliente.IdEndereco;
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

            _clienteRepository.Update(dbResult);
             _context.SaveChanges();

            return new Tuple<bool, string>(true, "Atualizado com Sucesso!");
        }
        public async Task<Tuple<bool, string>> Delete(int id)
        {
            var cliente =  _clienteRepository.GetById(id);

            if (cliente is null)
            {
                return new Tuple<bool, string>(false, "Cliente não existente");
            }
            _clienteRepository.Delete(cliente);
            _context.SaveChanges();

            return new Tuple<bool, string>(true, "Removido com sucesso!"); ;
        }
    }
}
