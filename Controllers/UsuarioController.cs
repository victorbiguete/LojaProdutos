using AutoMapper;
using LojaProdutos.DTOs.Endereço;
using LojaProdutos.DTOs.Usuario;
using LojaProdutos.Services.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace LojaProdutos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioInterface _usuarioInterface;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioInterface usuarioInterface,IMapper mapper)
        {
            _usuarioInterface = usuarioInterface;
            _mapper = mapper;
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

        public async Task<IActionResult> Editar(int id)
        {
            var usuario = await _usuarioInterface.BuscarUsuarioPorId(id);

            var usuarioEditado = new EditarUsuarioDTO
            {
                Nome = usuario.Nome,
                Cargo = usuario.Cargo,
                Email = usuario.Email,
                Id = usuario.Id,
                Endereco = _mapper.Map<EditarEnderecoDTO>(usuario.Endereco),
            };
            return View(usuarioEditado);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(EditarUsuarioDTO editarUsuarioDTO)
        {
            if(ModelState.IsValid)
            {
                var usuario = await _usuarioInterface.Editar(editarUsuarioDTO);

                TempData["MensagemSucesso"] = "Edição Realizada com Sucesso";

                return RedirectToAction("Index");
            }
            else
            {
                TempData["MensagemErro"] = "Verifique os Dados Informados";
            }
            return View(editarUsuarioDTO);
        }
    }
}
