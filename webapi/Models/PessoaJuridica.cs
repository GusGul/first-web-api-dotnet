using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    [Table("fornecedores")]
    public class PessoaJuridica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CNPJ { get; set; }
        public DateTime DataCriacao { get; set; }

        public ICollection<Orcamento>? Orcamentos { get; set; }
    }
}
