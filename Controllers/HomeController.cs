using LojaProdutos.Filtros;
using LojaProdutos.Models;
using LojaProdutos.Services.Produto;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LojaProdutos.Controllers
{
    [UsuarioLogado]
    public class HomeController : Controller
    {
        private readonly IProdutoInterface _produtoInterface;

        public HomeController(IProdutoInterface produtoInterface)
        {
            _produtoInterface = produtoInterface;
        }

        public async Task<IActionResult> Index(string? pesquisar)
        {
            List<ProdutoModel> produtos = new List<ProdutoModel>();

            if(string.IsNullOrWhiteSpace(pesquisar))
            {
                produtos = await _produtoInterface.BuscarProdutos();
            }
            else
            {
                produtos = await _produtoInterface.BuscarProdutoFiltro(pesquisar);
            }

            return View(produtos);
        }


        
    }
}
