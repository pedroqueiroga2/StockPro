using ControleDeEstoque.Application.DTO;
using ControleDeEstoque.Application.Interfaces;
using ControleDeEstoque.Domain.Entities;

using Microsoft.AspNetCore.Mvc;


namespace ControleDeEstoque.Api.Controllers;


public class ProdutoController : Controller
{
    private readonly IProdutoServices _produtoServices;
    private readonly IMotivosServices _motivosServices;
    private readonly IMovimentacaoEstoqueServices _movimentacaoServices;
    private readonly IRelatoriosServices _relatoriosServices;

    public ProdutoController(IProdutoServices produtoServices, IMotivosServices motivosServices, IMovimentacaoEstoqueServices movimentacaoServices, IRelatoriosServices relatoriosServices)
    {
        _produtoServices = produtoServices;
        _motivosServices = motivosServices;
        _movimentacaoServices = movimentacaoServices;
        _relatoriosServices = relatoriosServices;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string nome)
    {
        try
        {

            // Se não encontrar o produto, retorna erro 404
            return View(await _produtoServices.BuscaProduto(nome));
        }
        catch
        {
            return StatusCode(500);
        }



    }

    [HttpGet]
    public async Task<IActionResult> ImprimirSaida(int movimentacaoId)
    {
        try
        {
            byte[] pdfBytes = await _relatoriosServices.ImprimirSaida(movimentacaoId);

            Response.Headers.Append("Content-Disposition", "inline; filename=reciboDeVenda.pdf");
            return File(pdfBytes, "application/pdf");
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }

    }


    [HttpGet]
    public async Task<IActionResult> ConfirmacaoDeExclusao(int id)
    {
        var produto = await _produtoServices.ObterProdutoPorId(id);
        if (produto == null)
            return NotFound();

        return PartialView("ConfirmacaoDeExclusao", produto);
    }

    [HttpGet]
    public IActionResult AdicionarProduto()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> EntradaProduto(int id)
    {
        var produto = await _produtoServices.ObterProdutoPorId(id);

        // Se não encontrar o produto, retorna erro 404
        if (produto == null)
            return NotFound("Produto não encontrado.");

        // 2. Envia o produto encontrado para a View!
        return View(produto);
    }
    [HttpGet]
    public async Task<IActionResult> SaidaProduto(int id)
    {
        var produto = await _produtoServices.ObterProdutoPorId(id);
        ViewBag.ListarMotivos = await _motivosServices.ListaMotivosDeSaida();

        // Se não encontrar o produto, retorna erro 404
        if (produto == null)
            return NotFound("Produto não encontrado.");

        // 2. Envia o produto encontrado para a View!
        return View(produto);
    }

    [HttpGet]
    public async Task<IActionResult> ListarMotivoSaida()
    {
        try
        {

            // Se não encontrar o produto, retorna erro 404
            return View(await _motivosServices.ListaMotivosDeSaida());
        }
        catch
        {
            return StatusCode(500);
        }



    }




    [HttpPost("CadastrarProduto")]
    public async Task<IActionResult> CadastrarProduto(ProdutoDto produto)
    {
        try
        {
            await _produtoServices.CadastrarProduto(produto);
            return RedirectToAction("Index");
        }
        catch
        {
            return StatusCode(500);
        }
    }

    [HttpPost("ExcluirProduto")]
    public async Task<IActionResult> ExcluirProduto(int id)
    {
        try
        {
            await _produtoServices.ExcluirProduto(id);
            return RedirectToAction("Index");
        }
        catch
        {
            return StatusCode(500);
        }
    }

    [HttpPost]
    public async Task<IActionResult> EntradaProduto(int id, int quantidade)
    {
        try
        {
            var produto = await _produtoServices.AdicionarEntradaProduto(id, quantidade);
            return RedirectToAction("Index");
        }
        catch
        {
            return StatusCode(500);
        }
    }


    [HttpPost]
    public async Task<IActionResult> SaidaProduto(int id, int quantidade, int cdmotivo)
    {
        try
        {
            var produto = await _produtoServices.SaidaDeProduto(id, quantidade, cdmotivo);

            var movimentacaoGeradaId = await _produtoServices.SaidaDeProduto(id, quantidade, cdmotivo);

            return RedirectToAction("SaidaSucesso", new { movimentacaoId = movimentacaoGeradaId });

        }
        catch
        {
            return StatusCode(500);
        }
    }

    [HttpGet]
    public IActionResult SaidaSucesso(int movimentacaoId)
    {
       
        ViewBag.MovimentacaoId = movimentacaoId;
        return View();
    }
}
