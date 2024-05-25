using Estudos.Domain.Entities;

namespace Estudos.Application.Interfaces
{
    public interface IViaCepService
    {
        Task<ViaCepResponse> Get(string cepId); 
    }
}
