using LojaProdutos.DTOs.Produto;
using LojaProdutos.Models;
using LojaProdutos.Services.Categoria;
using LojaProdutos.Services.Produto;
using Microsoft.AspNetCore.Mvc;

namespace LojaProdutos.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoInterface _produtoInterface;
        private readonly ICategoriaInterface _categoriaInterface;

        public ProdutoController(IProdutoInterface produtoInterface, ICategoriaInterface categoriaInterface)
        {
            _produtoInterface = produtoInterface;
            _categoriaInterface = categoriaInterface;
        }

        public async Task<IActionResult> Index()
        {
            var produtos =  await _produtoInterface.BuscarProdutos();

            return View(produtos);
        }

        public async Task<IActionResult> Cadastrar()
        {
            ViewBag.Categorias = await _categoriaInterface.BuscarCategorias();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(CriarProdutoDTO criarDTOProduto, IFormFile foto)
        {
            if(ModelState.IsValid)
            {
                var produto = _produtoInterface.Cadastrar(criarDTOProduto, foto);
                return RedirectToAction("Index","Produto");
            }
            else
            {
                ViewBag.Categorias = await _categoriaInterface.BuscarCategorias();
                return View();
            }

        }
    }
}
