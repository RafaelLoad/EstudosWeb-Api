using Estudos.Application.Interfaces.ApiServices;
using Estudos.Domain.ViewModels;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Estudos.Api.ApiServices
{
    public class AutenticacaoApiService : IAutenticacaoApiService
    {
        private readonly HttpClient _httpClient;
        public AutenticacaoApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Autenticar(LoginDTO login)
        {
            try
            {
                var loginAutenticacao = new { Usuario = login.Usuario, Senha = login.Senha };
                var jsonLogin = JsonSerializer.Serialize(loginAutenticacao);

                var conteudoEnvio = new StringContent(jsonLogin, Encoding.UTF8, "application/json");
                var resposta = await _httpClient.PostAsync($"/api/Login/Autenticar", conteudoEnvio);

                var conteudoResposta = await resposta.Content.ReadAsStringAsync();

                if (resposta.IsSuccessStatusCode)
                    return conteudoResposta;
                else if (resposta.StatusCode == HttpStatusCode.BadRequest)
                    throw new Exception("Usuário ou senha inválidos.");
                else
                    throw new Exception($"Erro ao autenticar: {resposta.StatusCode}");
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao autenticar.", ex);
            }
        }
    }
}

