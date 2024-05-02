using Estudos.Domain.Entities;
using Estudos.Domain.ViewModel;

namespace Estudos.Application.Interfaces
{
    public interface ILoginService
    {
        Task<bool> Add(LibraryViewModel obj);
        Task<User> Alter(LibraryViewModel obj);
        Task<User> GetById(int id);
        Task<List<User>> GetAll(LibraryViewModel obj);
        Task<bool> Delete(LibraryViewModel obj);
    }
}
