using ControleDeEstoque.Domain.Entities;

namespace ControleDeEstoque.Application.Interfaces;

public interface IMotivosServices
{
    Task<bool> cancelarMotivo(int id);

    Task<MotivosModel> CriarMotivos(MotivosModel motivo);

    Task<MotivosModel> ExcluirMotivo(int id);
    Task<MotivosModel> EditMotivo(MotivosModel motivo);
    Task<MotivosModel> ObterMotivoPorId(int id);
    Task<IEnumerable<MotivosModel>> ListaTodosMotivos();

    Task<IEnumerable<MotivosModel>> ListaMotivosDeEntrada();

    Task<IEnumerable<MotivosModel>> ListaMotivosDeSaida();
}
