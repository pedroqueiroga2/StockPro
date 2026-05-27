using ControleDeEstoque.Domain.Data;
using ControleDeEstoque.Domain.Entities;
using ControleDeEstoque.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.Infrastructure.Repository;

public class MovimentacaoEstoqueRepository : IMovimentacaoEstoqueRepository
{

    private readonly AppDbContext _context;



    public MovimentacaoEstoqueRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<MovimentacaoEstoqueModel> BuscarPorId(int id)
    {
       return await _context.cadMovimentacaoEstoque
            .Include(a => a.Produto)
            .FirstOrDefaultAsync(a => a.cdMovimentacaoEstoque == id);
    }

    public async Task<MovimentacaoEstoqueModel> Create(MovimentacaoEstoqueModel movimentacao)
    {
        try
        {
            if (movimentacao != null)
            {
            
            await _context.cadMovimentacaoEstoque.AddAsync(movimentacao);
             await _context.SaveChangesAsync();
            }
                return movimentacao;
           
        }
        catch (Exception ex) 
        {

            throw ex;
        }
    }

    public Task<IEnumerable<MovimentacaoEstoqueModel>> listarTodos()
    {
        throw new NotImplementedException();
    }
}
