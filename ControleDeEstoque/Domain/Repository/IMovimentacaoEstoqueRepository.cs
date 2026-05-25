using ControleDeEstoque.Domain.Entities;

namespace ControleDeEstoque.Domain.Repository;

public interface IMovimentacaoEstoqueRepository
{
    Task<MovimentacaoEstoqueModel> Create(MovimentacaoEstoqueModel movimentacao);
    Task<IEnumerable<MovimentacaoEstoqueModel>> listarTodos();
}
