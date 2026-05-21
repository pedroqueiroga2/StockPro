namespace ControleDeEstoque.Application.DTO;

public class MotivosDto
{
    public int cdMotivo { get; set; }
    public string nmMotivo { get; set; }
    public string dsMotivo { get; set; }

    public DateTime dtCriacao { get; set; }

    public int cancelado { get; set; }
}
