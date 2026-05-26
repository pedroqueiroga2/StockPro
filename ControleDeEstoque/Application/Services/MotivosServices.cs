using ControleDeEstoque.Application.Interfaces;
using ControleDeEstoque.Domain.Entities;
using ControleDeEstoque.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.Application.Services;

public class MotivosServices : IMotivosServices
{
    private readonly IMotivosRepository _motivosRepository;

    public MotivosServices(IMotivosRepository motivosRepository)
    {
        _motivosRepository = motivosRepository;
    }

    public async Task<MotivosModel> EditMotivo(MotivosModel motivo)
    {
        try
        {
            var motivoCadastrado = await _motivosRepository.ObterMotivoPorId((int)motivo.cdMotivo);
        
            if (motivoCadastrado != null) 
            {
                motivoCadastrado.nmMotivo = motivo.nmMotivo;
                motivoCadastrado.dsMotivo = motivo.dsMotivo;
                motivoCadastrado.dtAlteracao = DateTime.UtcNow;
            }
           
                return motivoCadastrado;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<bool> cancelarMotivo(int id)
    {
        try
        {
            var motivo = await _motivosRepository.ObterMotivoPorId(id);
            motivo.cancelado = true;
            if (!(bool)motivo.cancelado) 
            {
                return false;
            }
            await _motivosRepository.AtualizarMotivo(motivo);
            return true;
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
            var novoMotivo = new MotivosModel 
            {
                nmMotivo = motivo.nmMotivo,
                dsMotivo = motivo.dsMotivo,
                dtCriacao = DateTime.UtcNow
            };
            await _motivosRepository.CriarMotivos(novoMotivo);
           

            return novoMotivo;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<IEnumerable<MotivosModel>> ListaMotivosDeSaida()
    {
        try
        {
            return await _motivosRepository.ListaMotivosPeloTipo(2);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public async Task<IEnumerable<MotivosModel>> ListaMotivosDeEntrada()
    {
        try
        {
            return await _motivosRepository.ListaMotivosPeloTipo(1);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<MotivosModel> ExcluirMotivo(int id)
    {
        try
        {
            var motivoExcluir = await _motivosRepository.ObterMotivoPorId(id);

            if (motivoExcluir == null)
            {
                throw new Exception("Nenhum motivo encontrado com o ID fornecido.");
            }

            await _motivosRepository.ExcluirMotivo(motivoExcluir);


            return motivoExcluir;
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
            return await _motivosRepository.ListaTodosMotivos();
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
            return await _motivosRepository.ObterMotivoPorId(id);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
