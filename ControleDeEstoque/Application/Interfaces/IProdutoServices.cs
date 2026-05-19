using ControleDeEstoque.Domain.Entities;
using ControleDeEstoque.Application.DTO;

namespace ControleDeEstoque.Application.Interfaces;

public interface IProdutoServices
{
    Task<ProdutoModel> CadastrarProduto(ProdutoDto produto);
    Task<ProdutoModel> AtualizarProduto(ProdutoDto produto);
    Task<IEnumerable<ProdutoModel>> ObterTodos();
    Task<bool> ExcluirProduto(int id);
    Task<ProdutoModel> ObterProdutoPorId(int id);
    Task<ProdutoModel> AdicionarEntradaProduto(int id, int quantidade);
    Task<IEnumerable<ProdutoModel>> BuscaProduto(string nome);
}
