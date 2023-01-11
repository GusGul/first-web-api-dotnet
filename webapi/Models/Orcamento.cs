using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    [Table("orcamentos")]
    public class Orcamento
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public PessoaFisica? Cliente { get; set; }
        public int FornecedorId { get; set; }
        [ForeignKey("FornecedorId")]
        public PessoaJuridica? Fornecedor { get; set; }
        public string DescricaoDoServico { get; set; }
        public float ValorTotal { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}
