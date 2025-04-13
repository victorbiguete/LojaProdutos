using LojaProdutos.Data;
using LojaProdutos.Models;
using LojaProdutos.Services.Produto;

namespace LojaProdutos.Services.Estoque
{
    public class EstoqueService : IEstoqueInterface
    {
        private readonly AppDbContext _context;
        private readonly IProdutoInterface _produtoInterface;

        public EstoqueService(AppDbContext context, IProdutoInterface produtoInterface)
        {
            _context = context;
            _produtoInterface = produtoInterface;
        }

        public async Task<ProdutosBaixadosModel> CriarRegistro(int ProdutoId)
        {
            try
            {
                var produto = await _produtoInterface.BuscarProdutoPorId(ProdutoId);

                var produtoBaixado = new ProdutosBaixadosModel
                {
                    ProdutoModelId = ProdutoId,
                    Produto = produto,
                };

                _context.Add(produtoBaixado);
                await _context.SaveChangesAsync();

                BaixarEstoque(produto);

                _context.Produtos.Update(produto);
                await _context.SaveChangesAsync();

                return produtoBaixado;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void BaixarEstoque(ProdutoModel produto)
        {
            produto.QuantidadeEstoque--;
        }
    }
}
