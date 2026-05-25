using ControleDeEstoque.Domain.Entities;

namespace ControleDeEstoque.Application.Interfaces;

public interface IMovimentacaoEstoqueServices
{
    Task<MovimentacaoEstoqueModel> Create(int cdProduto, int cdMotivo, double vlUnitario, double valorTotal, int qtSaldoFinal);
    Task<IEnumerable<MovimentacaoEstoqueModel>> listarTodos();
}
