using ControleDeEstoque.Domain.Data;
using ControleDeEstoque.Domain.Entities;
using ControleDeEstoque.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Fastenshtein;

namespace ControleDeEstoque.Infrastructure.Repository;

public class ProdutoRepository : IProdutoRepository
{

    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ProdutoModel> AtualizarProduto(ProdutoModel produto)
    {
        _context.cadProdutos.Update(produto);
        await _context.SaveChangesAsync();
        return (produto);
    }

    public async Task<ProdutoModel> AtualizarProduto(int id)
    {
        try
        {
            var produto = await ObterProdutoPorId(id);

            _context.Update(produto);
            _context.SaveChanges();

            return produto;


        }
        catch (Exception ex)
        {
            throw new Exception("Erro: ", ex);
        }
    }

    public async Task<IEnumerable<ProdutoModel>> BuscaProduto(string nome)
    {
        var listaProdutos = (await ObterTodos()).ToList();

  

        var nomeDigitado = nome.Trim().ToUpper();

        var listaProdutosFiltrados = listaProdutos.Where(a =>
        {
            if (string.IsNullOrEmpty(a.nmProduto)) return false;

            var nomeProdutoBanco = a.nmProduto.Trim().ToUpper();

            // 1. Se conter o texto exato (ex: digitou "Headset" ou "7.1"), já entra direto
            if (nomeProdutoBanco.Contains(nomeDigitado)) return true;

            // 2. Quebra o nome do banco por espaços (vai virar um array: ["HEADSET", "7.1"])
            var palavrasDoProduto = nomeProdutoBanco.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // 3. Compara a sua busca com cada palavra isolada do produto
            foreach (var palavra in palavrasDoProduto)
            {
                // Se a distância de "headser" para "HEADSET" for menor ou igual a 2, funcionou!
                if (Levenshtein.Distance(palavra, nomeDigitado) <= 2)
                {
                    return true;
                }
            }

            return false;
        }).ToList();

        return listaProdutosFiltrados;
    }

    public async Task<ProdutoModel> CadastrarProduto(ProdutoModel produto)
    {
        try
        {
            await _context.cadProdutos.AddAsync(produto);
            await _context.SaveChangesAsync();
            return produto;

        }
        catch (Exception ex)
        {
            throw new Exception("Erro: ", ex);
        }
    }

    public async Task<bool> ExcluirProduto(int id)
    {
        try
        {
            var produtoPraExcluir = await ObterProdutoPorId(id);

            if (produtoPraExcluir == null)
            {
                throw new Exception($"Você não pode excluir um produto que não existe");
            }
            _context.cadProdutos.Remove(produtoPraExcluir);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Houve um erro ao excluir {ex.Message}");
            return false;
        }

    }

    public async Task<ProdutoModel> ObterProdutoPorId(int id)
    {
        try
        {
            return await _context.cadProdutos.FirstOrDefaultAsync(a => a.cdProduto == id);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro: ", ex);
        }
    }

    public async Task<IEnumerable<ProdutoModel>> ObterTodos()
    {
        return await _context.cadProdutos.ToListAsync();
    }
}
