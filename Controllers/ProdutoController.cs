﻿using LojaProdutos.DTOs.Produto;
using LojaProdutos.Filtros;
using LojaProdutos.Models;
using LojaProdutos.Services.Categoria;
using LojaProdutos.Services.Produto;
using Microsoft.AspNetCore.Mvc;

namespace LojaProdutos.Controllers
{
    [UsuarioLogado]
    public class ProdutoController : Controller
    {
        private readonly IProdutoInterface _produtoInterface;
        private readonly ICategoriaInterface _categoriaInterface;

        public ProdutoController(IProdutoInterface produtoInterface, ICategoriaInterface categoriaInterface)
        {
            _produtoInterface = produtoInterface;
            _categoriaInterface = categoriaInterface;
        }

        [UsuarioLogadoAdm]
        public async Task<IActionResult> Index()
        {
            var produtos =  await _produtoInterface.BuscarProdutos();

            return View(produtos);
        }

        [UsuarioLogadoAdm]
        public async Task<IActionResult> Cadastrar()
        {
            ViewBag.Categorias = await _categoriaInterface.BuscarCategorias();
            return View();
        }

        [HttpPost]
        [UsuarioLogadoAdm]
        public async Task<IActionResult> Cadastrar(CriarProdutoDTO criarDTOProduto, IFormFile foto)
        {
            if(ModelState.IsValid)
            {
                var produto = _produtoInterface.Cadastrar(criarDTOProduto, foto);
                TempData["MensagemSucesso"] = "Produto Cadastrado com sucesso !";
                return RedirectToAction("Index","Produto");
            }
            else
            {
                TempData["MensagemErro"] = "Ocorreu algum erro no processo !";
                ViewBag.Categorias = await _categoriaInterface.BuscarCategorias();
                return View();
            }

        }

        [UsuarioLogadoAdm]
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
        [UsuarioLogadoAdm]
        public async Task<IActionResult> Editar(EditarProdutoDTO editarProdutoDTO, IFormFile? foto)
        {
            if(ModelState.IsValid)
            {
                var produto = await _produtoInterface.Editar(editarProdutoDTO,foto);
                TempData["MensagemSucesso"] = "Produto Editado com sucesso !";

                return RedirectToAction("Index","Produto");
            }
            else
            {
                ViewBag.Categorias = await _categoriaInterface.BuscarCategorias();
                TempData["MensagemErro"] = "Ocorreu algum erro no processo !";

                return View(editarProdutoDTO);
            }

        }

        [UsuarioLogadoAdm]
        public async Task<IActionResult> Remover (int id)
        {
            var produto = await _produtoInterface.Remover(id);

            return RedirectToAction("Index", "Produto");
        }

        public async Task<IActionResult> Detalhes (int id)
        {
            var produto = await _produtoInterface.BuscarProdutoPorId(id);
            return View(produto);
        }
    }
}
