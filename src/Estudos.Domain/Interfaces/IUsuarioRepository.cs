using Estudos.Domain.Entities;

namespace Estudos.Domain.Interfaces
{
    public interface IUsuarioRepository : ICrudRepository<User>
    {
        User Get(string usuario);
    }
}
