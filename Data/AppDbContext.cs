using LojaProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaProdutos.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<ProdutosBaixadosModel> ProdutosBaixados {get; set;}
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CategoriaModel>().HasData(
                new CategoriaModel { Id = 1, Nome = "Tenis" },
                new CategoriaModel { Id = 2, Nome = "Botas" },
                new CategoriaModel { Id = 3, Nome = "Chinelos" },
                new CategoriaModel { Id = 4, Nome = "Sandalia" },
                new CategoriaModel { Id = 5, Nome = "Sapatos" }
            );
        }
    }
}
