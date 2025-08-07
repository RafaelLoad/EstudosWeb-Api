namespace Estudos.Domain.Entities
{
    public class ViaCepResponse
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }
        public string ddd { get; set; }
        public string siafi { get; set; }

        public bool Error { get; set; }
        public string Mensagem { get; set; }

        public ViaCepResponse(bool error, string mensagem)
        {
            Error = error;
            Mensagem = mensagem;
        }

        public bool CepValidacao()
        => string.IsNullOrEmpty(cep) &&
           string.IsNullOrEmpty(logradouro) &&
           string.IsNullOrEmpty(bairro) &&
           string.IsNullOrEmpty(localidade) &&
           string.IsNullOrEmpty(ddd) &&
           string.IsNullOrEmpty(uf);
    }
}