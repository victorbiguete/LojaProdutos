using LojaProdutos.Services.Estoque;
using Microsoft.AspNetCore.Mvc;

namespace LojaProdutos.Controllers
{
    public class EstoqueController : Controller
    {
        private readonly IEstoqueInterface _estoqueInterface;

        public EstoqueController(IEstoqueInterface estoqueInterface)
        {
            _estoqueInterface = estoqueInterface;
        }

        public IActionResult Index()
        {
            var registro = _estoqueInterface.ListagemRegistro();
            return View(registro);
        }
        [HttpPost]
        public async Task<IActionResult> BaixarEstoque(int id)
        {
            var produtoBaixado = await _estoqueInterface.CriarRegistro(id);
            TempData["MensagemSucesso"] = "Compra Realizada com Sucesso";
            return RedirectToAction("Index", "Home");
        }
    }
}
