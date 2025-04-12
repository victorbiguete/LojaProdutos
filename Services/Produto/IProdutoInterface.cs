using LojaProdutos.DTOs.Produto;
using LojaProdutos.Models;

namespace LojaProdutos.Services.Produto
{
    public interface IProdutoInterface
    {
        Task<List<ProdutoModel>> BuscarProdutos();
        Task<ProdutoModel> BuscarProdutoPorId(int id);
        Task<ProdutoModel> Cadastrar(CriarProdutoDTO criarProdutoDTO,IFormFile foto);
        Task<ProdutoModel> Editar(EditarProdutoDTO editarProdutoDTO, IFormFile? foto);

        //Task<ProdutoModel> 
    }
}
