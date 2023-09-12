using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProSoftNet.app_code
{
    public class Endereco
    {
        [MaxLength(100), Display(Name ="Descrição")]
        public string Description { get; set; }
        [MaxLength(100)]
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        [MaxLength(100)]
        public string Complemento { get; set; }
        [MaxLength(100)]
        public string Bairro { get; set; }
        [MaxLength(8)]
        public string CEP { get; set; }
        [MaxLength(100)]
        public string Cidade { get; set; }
        [MaxLength(2), Display(Name ="Estado")]
        public string UF { get; set; }
    }

    public class Cliente {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdCliente { get; set; }
        [MaxLength(100)]
        public string Nome { get; set; }
        [Display(Name ="Endereço")]
        public Endereco Endereco { get; set; }
        public virtual ICollection<Venda> Compras { get; set; } = new HashSet<Venda>();
    }

    public class Fornecedor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdFornecedor { get; set; }
        [MaxLength(100)]
        public string Nome { get; set; }
        [Display(Name = "Endereço")]
        public Endereco Endereco { get; set; }
        public virtual ICollection<Compra> Compras { get; set; } = new HashSet<Compra>();
    }

    public class Produto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdProduto { get; set; }
        public string Description { get; set; }
        [MaxLength(40)]
        public string Unidade { get; set; }
        public virtual ICollection<Movimento> Movimentos { get; set; } = new HashSet<Movimento>();
    }

    public enum TipoMovimento
    {
        Entrada,
        Saida
    }

    public abstract class Movimento
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdMovimento { get; set; }
        [Display(Name ="Produto")]
        public long Produto_IdProduto { get; set; }
        [ForeignKey(nameof(Produto_IdProduto))]
        public virtual Produto Produto { get; set; }
        public float Quantidade { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public float Total { get; set; }
    }

    public class Venda : Movimento
    {
        [Display(Name ="Cliente")]
        public long Cliente_IdCliente { get; set; }
        [ForeignKey("Cliente_IdCliente")]
        public virtual Cliente Cliente { get; set; }
    }

    public class Compra : Movimento
    {
        [Display(Name = "Fornecedor")]
        public long Fornecedor_IdFornecedor { get; set; }
        [ForeignKey("Fornecedor_IdFornecedor")]
        public virtual Fornecedor Fornecedor { get; set; }
    }
}
