namespace Estudos.Domain.DTO
{
    public class ClienteInputDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public EnderecoInputDTO Endereco { get; set; }
        public List<ContatoInputDTO> Contato { get; set; }
    }

    public class EnderecoInputDTO
    {
        public string Tipo { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Referencia { get; set; }
    }

    public class ContatoInputDTO
    {
        public string Tipo { get; set; }
        public int DDD { get; set; }
        public decimal Telefone { get; set; }
    }
}
