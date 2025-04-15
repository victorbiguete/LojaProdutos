using LojaProdutos.Models;

namespace LojaProdutos.Services.Usuario
{
    public interface IUsuarioInterface
    {
        Task<UsuarioModel> BuscarUsuarioPorId(int id);
        Task<List<UsuarioModel>> BuscarUsuarios();
    }
}
