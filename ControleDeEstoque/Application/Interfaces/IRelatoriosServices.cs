using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoque.Application.Interfaces;

public interface IRelatoriosServices
{
    Task<byte[]> ImprimirSaida(int movimentacaoId);
}
