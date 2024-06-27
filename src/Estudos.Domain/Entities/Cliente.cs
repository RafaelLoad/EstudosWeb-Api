using Estudos.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Estudos.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public Endereco? Endereco { get; set; }
        public ICollection<Contato> Contato { get; set; }
      
    }
}
