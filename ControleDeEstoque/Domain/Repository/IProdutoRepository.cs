using ControleDeEstoque.Domain.Entities;

namespace ControleDeEstoque.Domain.Repository;

public interface IProdutoRepository
{
    Task<ProdutoModel> CadastrarProduto(ProdutoModel produto);
    Task<ProdutoModel> AtualizarProduto(ProdutoModel produto);
    Task<bool> ExcluirProduto(int id);
    Task<IEnumerable<ProdutoModel>> ObterTodos();
    Task<ProdutoModel> ObterProdutoPorId(int id);

    Task<ProdutoModel> AtualizarProduto(int id);

    Task<IEnumerable<ProdutoModel>> BuscaProduto(string nome);



}
