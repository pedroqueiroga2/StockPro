using ControleDeEstoque.Domain.Entities;

namespace ControleDeEstoque.Domain.Repository;

public interface IMotivosRepository
{
    Task<MotivosModel> CriarMotivos(MotivosModel motivo);

    Task<MotivosModel> ExcluirMotivo(MotivosModel motivo);
    Task<MotivosModel> AtualizarMotivo(MotivosModel motivo);
    Task<MotivosModel> ObterMotivoPorId(int id);
    Task<IEnumerable<MotivosModel>> ListaTodosMotivos();
    Task<IEnumerable<MotivosModel>> ListaMotivosPeloTipo(int tpMotivo);
}
