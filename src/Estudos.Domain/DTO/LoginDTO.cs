
namespace Estudos.Domain.ViewModels
{
    public class LoginDTO
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }

        public bool EhValido(LoginDTO model)
            => string.IsNullOrEmpty(model.Usuario) || string.IsNullOrEmpty(model.Senha);

    }
}
