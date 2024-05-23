using Estudos.Domain.Entities;
using Estudos.Domain.ViewModels;

namespace Estudos.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<User> Buscar(LoginViewModel user);
    }
}
