using LojaProdutos.Services.Categoria;
using LojaProdutos.Services.Produto;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LojaProdutos.Middleware
{
    public static class ServicesInjection
    {
        public static void ServicesAndIterfaces(this WebApplicationBuilder builder)
        {
                    builder.Services.AddScoped<IProdutoInterface,ProdutoService>();
            builder.Services.AddScoped<ICategoriaInterface,CategoriaService>();
        }
    }
}
