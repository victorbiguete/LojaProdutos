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

        public async Task<IActionResult> Editar(int id)
        {
            var produto = await _produtoInterface.BuscarProdutoPorId(id);

            var editarProdutoDTO = new EditarProdutoDTO
            { 
                Id = produto.Id,
                Nome = produto.Nome,
                Marca = produto.Marca,
                Foto = produto.Foto,
                Valor = produto.Valor,
                QuantidadeEstoque = produto.QuantidadeEstoque,
                CategoriaModelId = produto.CategoriaModelId,
            };

            ViewBag.Categorias = await _categoriaInterface.BuscarCategorias();

            return View(editarProdutoDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(EditarProdutoDTO editarProdutoDTO, IFormFile? foto)
        {
            if(ModelState.IsValid)
            {
                var produto = await _produtoInterface.Editar(editarProdutoDTO,foto);
                return RedirectToAction("Index","Produto");
            }
            else
            {
                ViewBag.Categorias = await _categoriaInterface.BuscarCategorias();

                return View(editarProdutoDTO);
            }

        }



        public async Task<IActionResult> Remover (int id)
        {
            var produto = await _produtoInterface.Remover(id);

            return RedirectToAction("Index", "Produto");
        }
    }
}
