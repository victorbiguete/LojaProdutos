using LojaProdutos.Models;

namespace LojaProdutos.Services.Produto
{
    public interface IProdutoInterface
    {
        Task<List<ProdutoModel>> BuscarProdutos();
        Task<ProdutoModel> BuscarProdutoPorId(int id);
        //Task<ProdutoModel> 
    }
}
