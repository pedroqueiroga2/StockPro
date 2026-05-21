using ControleDeEstoque.Application.DTO;
using ControleDeEstoque.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ControleDeEstoque.Api.Controllers;


public class ProdutoController : Controller
{
    private readonly IProdutoServices _produtoServices;

    public ProdutoController(IProdutoServices produtoServices)
    {
        _produtoServices = produtoServices;
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

        // Se não encontrar o produto, retorna erro 404
        if (produto == null)
            return NotFound("Produto não encontrado.");

        // 2. Envia o produto encontrado para a View!
        return View(produto);
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
    public async Task<IActionResult> SaidaProduto(int id, int quantidade)
    {
        try
        {
            var produto = await _produtoServices.SaidaDeProduto(id, quantidade);
            return RedirectToAction("Index");
        }
        catch
        {
            return StatusCode(500);
        }
    }
}
