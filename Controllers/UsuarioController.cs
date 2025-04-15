using LojaProdutos.DTOs.Usuario;
using LojaProdutos.Services.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace LojaProdutos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioInterface _usuarioInterface;

        public UsuarioController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioInterface.BuscarUsuarios();
            return View(usuarios);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(CriarUsuarioDTO criarUsuarioDTO)
        {
            if(ModelState.IsValid)
            {
                if(await _usuarioInterface.VerificaSeExisteEmail(criarUsuarioDTO))
                {
                    TempData["MensagemErro"] = "Esse email já está cadastrado, tente outro";
                }
                var usuario = await _usuarioInterface.Cadastrar(criarUsuarioDTO);

                TempData["MensagemSucesso"] = "Cadastro realizado com Sucesso";

                return RedirectToAction("Index");
            }
            else
            {
                TempData["MensagemErro"] = "Verifique os Dados Informados";
                return View(criarUsuarioDTO);
            }
            
        }

        public IActionResult Cadastrar() { return View(); }
    }
}
