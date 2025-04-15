using LojaProdutos.Services.AutenticaçãoService;
using LojaProdutos.Services.Categoria;
using LojaProdutos.Services.Estoque;
using LojaProdutos.Services.Produto;
using LojaProdutos.Services.Usuario;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LojaProdutos.Middleware
{
    public static class ServicesInjection
    {
        public static void ServicesAndIterfaces(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IProdutoInterface,ProdutoService>();
            builder.Services.AddScoped<ICategoriaInterface,CategoriaService>();
            builder.Services.AddScoped<IEstoqueInterface,EstoqueService>(); 
            builder.Services.AddScoped<IUsuarioInterface,UsuarioService>();
            builder.Services.AddScoped<IAutenticacaoInterface,AutenticacaoService>();
        }
    }
}
