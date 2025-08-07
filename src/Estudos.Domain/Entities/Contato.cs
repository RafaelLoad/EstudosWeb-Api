namespace Estudos.Domain.Entities
{
    public class Contato
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }   
        public string Tipo { get; set; }
        public int DDD {  get; set; }
        public decimal Telefone { get; set; }
        public Cliente Cliente { get; set; }
    }
}
