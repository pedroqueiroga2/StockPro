using ControleDeEstoque.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.Domain.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ProdutoModel> cadProdutos { get; set; }
        public DbSet<MotivosModel> cadMotivos { get; set; }
        public DbSet<MovimentacaoEstoqueModel> cadMovimentacaoEstoque { get; set; }
    }
}
