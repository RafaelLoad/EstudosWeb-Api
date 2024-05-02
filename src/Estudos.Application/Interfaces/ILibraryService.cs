using Estudos.Domain.Entities;
using Estudos.Domain.ViewModel;

namespace Estudos.Application.Interfaces
{
    public interface ILibraryService
    {
        Task<bool> Add(LibraryViewModel obj);
        Task<Library> Alter(LibraryViewModel obj);
        Task<Library> GetById(int id);
        Task<List<Library>> GetAll(LibraryViewModel obj);
        Task<bool> Delete(LibraryViewModel obj);
    }
}
