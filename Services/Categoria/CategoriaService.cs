using LojaProdutos.Data;
using LojaProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaProdutos.Services.Categoria
{
    public class CategoriaService : ICategoriaInterface
    {
        private readonly AppDbContext _context;

        public CategoriaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CategoriaModel> BuscarCategoriaPorID(int id) 
        {
            try
            {
                return await _context.Categorias.Where(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 

        public async Task<List<CategoriaModel>> BuscarCategorias()
        {
            try
            {
                return await _context.Categorias.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        } 
        
    }
}
