using Estudos.Application.Interfaces.ApiServices;
using Estudos.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Estudos.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAutenticacaoApiService _autenticacaoService;
        public LoginController(IAutenticacaoApiService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }

        [HttpPost]
        public async Task<IActionResult> Autenticar(LoginDTO login)
        {
            if (login.EhValido(login))
                 return Json(new { sucess = false, mensagem = "Necessário preencher usuário e senha !" }); // implementar lib de notificacao

            var usuarioLogin = await _autenticacaoService.Autenticar(login);

            // adicionar validacao usuario
            //notificar erro, sem autorizacao
            return View("Error");

            return RedirectToAction("Index", "Usuarios");
        }
    }
}