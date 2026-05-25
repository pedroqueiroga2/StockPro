using System.ComponentModel.DataAnnotations;

namespace ControleDeEstoque.Domain.Entities;


public class MovimentacaoEstoqueModel
{
    [Key]
    public int cdMovimentacaoEstoque { get; set; }

    public string tpMovimentacao { get; set; }

    public int cdProduto { get; set; }
    public virtual ProdutoModel Produto { get; set; }

    public int cdMotivo { get; set; }
    public virtual MotivosModel Motivo { get; set; }

    public decimal qtMovimentacao { get; set; }

    public decimal? vlUnitario { get; set; }

    public decimal? vlTotal { get; set; }

    public decimal? qtSaldoFinal { get; set; }

    public string dsObservacao { get; set; }

    //public int? cdUsuario { get; set; }
    //public virtual UsuarioModel Usuario { get; set; }

    public DateTime dtMovimentacao { get; set; }
    public DateTime? dtAlteracao { get; set; }

    // Controle
    public bool cancelado { get; set; }
}
