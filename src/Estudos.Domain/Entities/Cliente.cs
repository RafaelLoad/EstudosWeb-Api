using System.ComponentModel.DataAnnotations;

namespace Estudos.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public int? IdEndereco { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string RG { get; set; }
        public Endereco Endereco { get; set; }
        public ICollection<Contato> Contato { get; set; }
    }
}
