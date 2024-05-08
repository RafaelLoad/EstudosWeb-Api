namespace Estudos.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }

        public int? IdEndereco { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public Endereco Endereco { get; set; }
        public List<Contato> Contato { get; set; }
    }
}
