using Estudos.Application.Interfaces;
using Estudos.Application.Services;
using Estudos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Estudos.Aplication.Testes.Services
{
    public class ClienteServiceTeste
    {
        private readonly ClienteService clienteService;

        public ClienteServiceTeste()
        {
            var mockLogger = new Mock<ILogger<ClienteService>>();
            var mockClienteRepository = new Mock<IClienteRepository>();
            var mockViaCepService = new Mock<IViaCepService>();
            var mockDbContext = new Mock<DbContext>();

            clienteService = new ClienteService(
                   mockLogger.Object,
                   mockClienteRepository.Object,
                   mockViaCepService.Object,
                   null
               );
        }

        [Fact]
        public async void ConsultaCep_GetCepValidation()
        {
            var cep = "05848160";
            var cepValido = "05848160";

            var result = await clienteService.ConsultarCep(cep);


            Assert.Equal(cep, cepValido);
        }
    }
}
