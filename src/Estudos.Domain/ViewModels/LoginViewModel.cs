
namespace Estudos.Domain.ViewModels
{
    public class LoginViewModel
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }

        public bool EhValido(LoginViewModel model)
            => string.IsNullOrEmpty(model.Usuario) || string.IsNullOrEmpty(model.Senha);

    }
}
