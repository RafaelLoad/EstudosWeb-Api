using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Estudos.Domain.Entities
{
    public class Endereco 
    {
        public int Id { get; set; } 
        public string Tipo { get; set; }
        [Required]
        public string CEP { get; set; }
        [Required]
        public string Logradouro { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Complemento {  get; set; }
        [Required]
        public string Cidade {  get; set; }
        [Required]
        public string Estado { get; set; }
        public string Referencia { get; set; }
    }
}
