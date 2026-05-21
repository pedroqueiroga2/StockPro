using System.ComponentModel.DataAnnotations;

namespace ControleDeEstoque.Domain.Entities;

public class MotivosModel
{
    [Key]
    public int? cdMotivo { get; set; }
    public string nmMotivo { get; set; }
    public string dsMotivo { get; set; }

    public DateTime? dtCriacao { get; set; }
    public DateTime? dtAlteracao { get; set; }

    public bool? cancelado { get; set; }
}
