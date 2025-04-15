using LojaProdutos.Models;

namespace LojaProdutos.Services.Sessão
{
    public interface ISessaoInterface
    {
        void CriarSessao(UsuarioModel usuario);
        void RemoverSessao();
        UsuarioModel BuscarSessao();
    }
}
