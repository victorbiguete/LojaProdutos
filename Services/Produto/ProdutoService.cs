using LojaProdutos.Data;
using LojaProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaProdutos.Services.Produto
{
    public class ProdutoService : IProdutoInterface
    {
        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public Task<ProdutoModel> BuscarProdutoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProdutoModel>> BuscarProdutos()
        {
            try
            {
                return await _context.Produtos.Include(x=>x.Categoria).ToListAsync(); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
