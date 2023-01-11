using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    [Table("clientes")]
    public class PessoaFisica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public DateTime DataCriacao { get; set; }

        public ICollection<Orcamento>? Orcamentos { get; set; }
    }
}
