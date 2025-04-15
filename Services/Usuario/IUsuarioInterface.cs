using LojaProdutos.DTOs.Usuario;
using LojaProdutos.Models;

namespace LojaProdutos.Services.Usuario
{
    public interface IUsuarioInterface
    {
        Task<UsuarioModel> BuscarUsuarioPorId(int id);
        Task<List<UsuarioModel>> BuscarUsuarios();
        Task<bool> VerificaSeExisteEmail(CriarUsuarioDTO criarUsuarioDTO);
        Task<CriarUsuarioDTO> Cadastrar(CriarUsuarioDTO criarUsuarioDTO);
    }
}
