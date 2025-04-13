using LojaProdutos.Data;
using LojaProdutos.DTOs.Produto;
using LojaProdutos.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace LojaProdutos.Services.Produto
{
    public class ProdutoService : IProdutoInterface
    {
        private readonly AppDbContext _context;
        private readonly string _sistema;

        public ProdutoService(AppDbContext context, IWebHostEnvironment sistema)
        {
            _context = context;
            _sistema = sistema.WebRootPath;
        }

        public async Task<List<ProdutoModel>> BuscarProdutoFiltro(string pesquisar)
        {
            try
            {
                return await _context.Produtos.Include(x => x.Categoria)
                                              .Where(x => x.Nome.Contains(pesquisar) || 
                                                          x.Marca.Contains(pesquisar))
                                              .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoModel> BuscarProdutoPorId(int id)
        {
            try
            {
                return await _context.Produtos.Include(x => x.Categoria)
                                              .Where(x => x.Id == id)
                                              .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ProdutoModel>> BuscarProdutos()
        {
            try
            {
                return await _context.Produtos.Include(x => x.Categoria).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoModel> Cadastrar(CriarProdutoDTO criarProdutoDTO, IFormFile foto)
        {
            try
            {
                var nomeCaminhoImagem = GerarCaminhoArquivo(foto);
                var produto = new ProdutoModel
                {
                    Nome = criarProdutoDTO.Nome,
                    Marca = criarProdutoDTO.Marca,
                    Valor = criarProdutoDTO.Valor,
                    CategoriaModelId = criarProdutoDTO.CategoriaModelId,
                    Foto = nomeCaminhoImagem,
                    QuantidadeEstoque = criarProdutoDTO.QuantidadeEstoque
                };
                _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();

                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoModel> Editar(EditarProdutoDTO editarProdutoDTO, IFormFile? foto)
        {
            try
            {
                var produto = await BuscarProdutoPorId(editarProdutoDTO.Id);
                var nomeCaminhoImagem = "";

                if (foto!=null)
                {
                    string caminhoCapaExistente = _sistema + "\\imamgem\\" + produto.Foto;
                    if(File.Exists(caminhoCapaExistente))
                        File.Delete(caminhoCapaExistente);

                    nomeCaminhoImagem = GerarCaminhoArquivo(foto);
                }

                produto.Nome = editarProdutoDTO.Nome;
                produto.Valor = editarProdutoDTO.Valor;
                produto.CategoriaModelId = editarProdutoDTO.CategoriaModelId;
                produto.QuantidadeEstoque = editarProdutoDTO.QuantidadeEstoque;
                produto.Marca = editarProdutoDTO.Marca;

                if (nomeCaminhoImagem != "")
                    produto.Foto = nomeCaminhoImagem;

                _context.Update(produto);
                _context.SaveChangesAsync();

                return produto;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoModel> Remover(int id)
        {
            try
            {
                var produto = await BuscarProdutoPorId(id);
                _context.Remove(produto);

                await _context.SaveChangesAsync();

                return produto;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string GerarCaminhoArquivo(IFormFile foto)
        {
            var codigoUnico = Guid.NewGuid().ToString();
            var nomeCaminhoImagem = foto.FileName.Replace(" ","").ToLower() + codigoUnico + ".png";

            var caminhoParaSalvarImagens = _sistema + "\\imagem\\";

            if(!Directory.Exists(caminhoParaSalvarImagens))
                Directory.CreateDirectory(caminhoParaSalvarImagens);
            
            using(var stream = File.Create(caminhoParaSalvarImagens+nomeCaminhoImagem))
            {
                foto.CopyToAsync(stream).Wait();
            }

            return nomeCaminhoImagem;
        }
    }
}
