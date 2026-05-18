using ControleDeEstoque.Application.DTO;
using ControleDeEstoque.Application.Interfaces;
using ControleDeEstoque.Domain.Entities;
using ControleDeEstoque.Domain.Repository;

namespace ControleDeEstoque.Application.Services
{
    public class ProdutoServices : IProdutoServices
    {

        private readonly IProdutoRepository _produtoRepository;

        public ProdutoServices(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<ProdutoModel> AdicionarEntradaProduto(int id, int quantidade)
        {
            try
            {
                var produto = await _produtoRepository.ObterProdutoPorId(id);
                if (produto is null)
                {
                    throw new ArgumentException("Produto não encontrado.");
                }

                produto.qtdEstoque += quantidade;
                await _produtoRepository.AtualizarProduto(id);
                return produto;
                
            }
            catch (Exception ex) 
            {
                throw new Exception("Mensagem de erro:" + ex);
            }
        }

        public async Task<ProdutoModel> AtualizarProduto(ProdutoDto produto)
        {
            var produtoAtualizado = new ProdutoModel
            {
                nmProduto = produto.nmProduto,
                Preco = produto.Preco,
                qtdEstoque = produto.qtdEstoque,


            };
            return await _produtoRepository.AtualizarProduto(produtoAtualizado);
        }

        public async Task<ProdutoModel> CadastrarProduto(ProdutoDto produto)
        {
            try {
                var produtoNovo = new ProdutoModel
                {
                    nmProduto = produto.nmProduto,
                    Preco = produto.Preco,
                    qtdEstoque = produto.qtdEstoque,

                };
            
            return await _produtoRepository.CadastrarProduto(produtoNovo);
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
                return await _produtoRepository.ExcluirProduto(id);
            }
            catch (Exception ex) 
            {
                throw new Exception("Erro: ", ex);
            }
        }

        public async Task<ProdutoModel> ObterProdutoPorId(int id)
        {
            try
            {
                return await _produtoRepository.ObterProdutoPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: ", ex);
            }
        }

        public Task<IEnumerable<ProdutoModel>> ObterTodos()
        {
            var ListarTodos = _produtoRepository.ObterTodos();
            if (ListarTodos is null) {
                throw new InvalidOperationException("O produto não existe");
            }
            return ListarTodos;
        }
    }
}
