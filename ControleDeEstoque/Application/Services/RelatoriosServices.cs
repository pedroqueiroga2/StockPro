using ControleDeEstoque.Application.Interfaces;
using ControleDeEstoque.Domain.Repository;
using FastReport;
using FastReport.Export.PdfSimple;

namespace ControleDeEstoque.Application.Services;

public class RelatoriosServices : IRelatoriosServices
{
    private readonly IMovimentacaoEstoqueRepository _movimentacaoEstoqueRepository;
    private readonly IWebHostEnvironment _env;
    public RelatoriosServices(IMovimentacaoEstoqueRepository movimentacaoEstoqueRepository, IWebHostEnvironment env)
    {
        _movimentacaoEstoqueRepository = movimentacaoEstoqueRepository;
        _env = env;
    }

    public async Task<byte[]> ImprimirSaida(int movimentacaoId)
    {

        var movimentacao = await _movimentacaoEstoqueRepository.BuscarPorId(movimentacaoId);

        if (movimentacao == null)
        {
            throw new KeyNotFoundException("A movimentação solicitada não foi encontrada no banco de dados.");
        }

        string reportPath = Path.Combine(_env.WebRootPath, "Reports", "reciboVenda.frx");

        using (var report = new Report())
        {
            report.Load(reportPath);

            report.SetParameterValue("NomeProduto", movimentacao.Produto?.nmProduto ?? "Desconhecido");
            report.SetParameterValue("Quantidade", movimentacao.qtMovimentacao);
            report.SetParameterValue("DataMovimentacao", movimentacao.dtMovimentacao.ToString("dd/MM/yyyy HH:mm"));
          
            report.Prepare();

            using (var ms = new MemoryStream())
            {
                var pdfExport = new PDFSimpleExport();
                pdfExport.Export(report, ms);

                return ms.ToArray();
            }
        }

    }
}
