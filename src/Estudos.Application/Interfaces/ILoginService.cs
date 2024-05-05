using Estudos.Domain.Entities;
using Estudos.Domain.ViewModel;

namespace Estudos.Application.Interfaces
{
    public interface ILoginService
    {
        Task<bool> Add(LibraryViewModel obj);
        Task<Cliente> Alter(LibraryViewModel obj);
        Task<Cliente> GetById(int id);
        Task<List<Cliente>> GetAll(LibraryViewModel obj);
        Task<bool> Delete(LibraryViewModel obj);
    }
}
