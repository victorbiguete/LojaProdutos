using LojaProdutos.Data;
using LojaProdutos.Models;
using LojaProdutos.Services.Produto;
using Microsoft.EntityFrameworkCore;

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

        public List<RegistroProdutosModel> ListagemRegistro()
        {
            try
            {
                var resultado = from c in _context.ProdutosBaixados.Include(x => x.Produto).Include(y => y.Produto.Categoria).ToList() group c by new
                    {
                        c.Produto.CategoriaModelId,
                        c.DataDaBaixa
                    } into total select new
                    {
                        ProdutoId = total.First().Produto.Categoria.Id,
                        CategoriaNome = total.First().Produto.Categoria.Nome,
                        DataCompra = total.First().DataDaBaixa,
                        Total = total.Sum(c => c.Produto.Valor)
                    };

                var totalGeral = _context.ProdutosBaixados.Include(x => x.Produto).Include(y => y.Produto.Categoria).Sum(c => c.Produto.Valor);

                List<RegistroProdutosModel> lista = new List<RegistroProdutosModel>();

                foreach(var result in resultado)
                {
                    var registro = new RegistroProdutosModel
                    {
                        ProdutoId = result.ProdutoId,
                        CategoriaNome = result.CategoriaNome,
                        DataCompra = result.DataCompra,
                        Total = result.Total,
                        TotalGeral = totalGeral
                    };
                    lista.Add(registro);
                }

                return lista;
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
