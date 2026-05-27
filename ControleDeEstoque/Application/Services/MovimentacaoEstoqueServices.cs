using ControleDeEstoque.Application.Interfaces;
using ControleDeEstoque.Domain.Entities;
using ControleDeEstoque.Domain.Repository;

namespace ControleDeEstoque.Application.Services;

public class MovimentacaoEstoqueServices : IMovimentacaoEstoqueServices
{

    private readonly IMovimentacaoEstoqueRepository _movimentacaoEstoqueRepository;
    private readonly IProdutoRepository _produtoRepository;

    public MovimentacaoEstoqueServices(IMovimentacaoEstoqueRepository movimentacaoEstoqueRepository, IProdutoRepository produtoRepository)
    {
        _movimentacaoEstoqueRepository = movimentacaoEstoqueRepository;
        _produtoRepository = produtoRepository;
    }

    public async Task<MovimentacaoEstoqueModel> BuscarPorId(int id)
    {
        try
        {
           
               var movimentacao = await  _movimentacaoEstoqueRepository.BuscarPorId(id);
                return movimentacao;
            
        }
        catch (Exception ex) 
        {
            throw ex;
        }
    }

    public async Task<MovimentacaoEstoqueModel> Create(int cdProduto, int cdMotivo, double vlUnitario, double valorTotal, int qtSaldoFinal)
    {

        var produto = await _produtoRepository.ObterProdutoPorId(cdProduto);
        var movimentacao = new MovimentacaoEstoqueModel
        {
            cdProduto = cdProduto,
            cdMotivo = cdMotivo,

            vlUnitario = (decimal)vlUnitario,
            vlTotal = (decimal)valorTotal,
            tpMovimentacao = "Teste",
            qtSaldoFinal = qtSaldoFinal,

            //dsObservacao = "Entrada de produtos no estoque",

            dtMovimentacao = DateTime.UtcNow,
            dtAlteracao = null,

            cancelado = false

        };

        return await _movimentacaoEstoqueRepository.Create(movimentacao);



    }

    public Task<IEnumerable<MovimentacaoEstoqueModel>> listarTodos()
    {
        throw new NotImplementedException();
    }
}
