using Microsoft.AspNetCore.Mvc;

namespace LojaProdutos.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
