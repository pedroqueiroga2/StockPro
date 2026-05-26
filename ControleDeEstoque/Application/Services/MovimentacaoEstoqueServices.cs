using ControleDeEstoque.Application.Interfaces;
using ControleDeEstoque.Domain.Entities;
using ControleDeEstoque.Domain.Repository;

namespace ControleDeEstoque.Application.Services;

public class MovimentacaoEstoqueServices : IMovimentacaoEstoqueServices
{

    private readonly IMovimentacaoEstoqueRepository _movimentacaoEstoqueRepository;

    public MovimentacaoEstoqueServices(IMovimentacaoEstoqueRepository repository)
    {
        _movimentacaoEstoqueRepository = repository;
    }

    public async Task<MovimentacaoEstoqueModel> Create(int cdProduto, int cdMotivo, double vlUnitario, double valorTotal, int qtSaldoFinal)
    {
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
