using ControleDeEstoque.Domain.Data;
using ControleDeEstoque.Domain.Entities;
using ControleDeEstoque.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.Infrastructure.Repository;

public class MotivosRepository: IMotivosRepository
{

    private readonly AppDbContext _context;

    public MotivosRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<MotivosModel> AtualizarMotivo(MotivosModel motivo)
    {
        try
        {
           var motivoAtualizado = _context.cadMotivos.Update(motivo);

            
             await _context.SaveChangesAsync();

            return motivoAtualizado.Entity;

        }
        catch (Exception ex)
        {
            throw ex;
        }
       
    }

   

    public async Task<MotivosModel> CriarMotivos(MotivosModel motivo)
    {
        try
        {
          var motivoCadastro =  await _context.cadMotivos.AddAsync(motivo);
            await _context.SaveChangesAsync();
            return motivoCadastro.Entity;
        }
        catch (Exception ex) 
        {
            throw ex;
        }
    }


    public async Task<IEnumerable<MotivosModel>> ListaMotivosPeloTipo(int tpMotivo)
    {
        try
        {
            var listaDeMotivosPorTipo = await _context.cadMotivos.Where(a => (int)a.tpMotivo == tpMotivo).ToListAsync();
                return listaDeMotivosPorTipo;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<MotivosModel> ExcluirMotivo(MotivosModel motivo)
    {
        try
        {
             _context.cadMotivos.Remove(motivo);

            await _context.SaveChangesAsync();

            return motivo;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<IEnumerable<MotivosModel>> ListaTodosMotivos()
    {
        try
        {
            var ListaDEMotivos = await _context.cadMotivos.OrderBy(a=> a.nmMotivo).ToListAsync();


            return ListaDEMotivos;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<MotivosModel> ObterMotivoPorId(int id)
    {
        try
        {
            var motivo = await _context.cadMotivos.Where(a => a.cdMotivo == id).FirstOrDefaultAsync();

          
            return motivo;
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
