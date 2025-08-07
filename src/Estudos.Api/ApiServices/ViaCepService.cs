using Estudos.Application.Interfaces;
using Estudos.Domain.Entities;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Estudos.Api.ViaCepService
{
    public class ViaCepService : IViaCepService
    {
        private readonly HttpClient _httpClient;
        public ViaCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ViaCepResponse> Buscar(string cep)
        {
            try
            {
                var viaCep = new { Cep = cep };
                var jsonCep = JsonSerializer.Serialize(viaCep);

                var conteudoEnvio = new StringContent(jsonCep, Encoding.UTF8, "application/json");
                var resposta = await _httpClient.GetAsync($"/ws/{cep}/json/");

                var conteudoResposta = await resposta.Content.ReadAsStringAsync();

                if (resposta.IsSuccessStatusCode)
                    return JsonSerializer.Deserialize<ViaCepResponse>(conteudoResposta);

                if (resposta.StatusCode.Equals(HttpStatusCode.BadRequest))
                    return JsonSerializer.Deserialize<ViaCepResponse>(conteudoResposta);

                return new ViaCepResponse(false, conteudoResposta.Replace('"', ' ').Replace("'", "").Trim());
            }
            catch (Exception ex)
            {
                return new ViaCepResponse(false, ex.Message);
            }

        }

    }
}
