using LojaProdutos.DTOs.Login;
using LojaProdutos.Services.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace LojaProdutos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioInterface _usuarioInterface;

        public LoginController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUsuarioDTO loginUsuarioDTO)
        {
            if(ModelState.IsValid)
            {
                var usuario = await _usuarioInterface.Login(loginUsuarioDTO);
                if( usuario == null)
                {
                    TempData["MensagemErro"] = "Credenciais Inválidas";
                    return View(loginUsuarioDTO);
                }
                TempData["MensagemSucesso"] = "Usuario Logado com sucesso";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["MensagemErro"] = "Verifique os dados informados";
                return View(loginUsuarioDTO);
            }
            
        }
    }
}
