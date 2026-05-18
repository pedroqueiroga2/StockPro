using ControleDeEstoque.Domain.Data;
using ControleDeEstoque.Domain.Entities;
using ControleDeEstoque.Domain.Repository;
using Microsoft.EntityFrameworkCore;

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
        _context.Produtos.Update(produto);
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

    public async Task<ProdutoModel> CadastrarProduto(ProdutoModel produto)
    {
        try
        {
            await _context.Produtos.AddAsync(produto);
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
            _context.Produtos.Remove(produtoPraExcluir);
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
            return await _context.Produtos.FirstOrDefaultAsync(a => a.cdProduto == id);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro: ", ex);
        }
    }

    public async Task<IEnumerable<ProdutoModel>> ObterTodos()
    {
        return await _context.Produtos.ToListAsync();
    }
}
