using System.ComponentModel.DataAnnotations;
using ControleDeEstoque.Domain.Enum;

namespace ControleDeEstoque.Domain.Entities;

public class ProdutoModel
{
    [Key]
    public int cdProduto { get; set; }
    public string nmProduto { get; set; }
    public string imgProduto { get; set; }
    public double Preco { get; set; }
    public int qtdEstoque { get; set; }
    public DateTime dtCriacao { get; set; } = DateTime.UtcNow;
    public TipoMotivo tipoMotivo { get; set; }
}
