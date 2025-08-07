using Estudos.Domain.Entities;
using Estudos.Domain.ViewModels;

namespace Estudos.Application.Interfaces.ApiServices
{
    public interface IAutenticacaoApiService
    {
        Task<string> Autenticar(LoginDTO login);
    }
}
