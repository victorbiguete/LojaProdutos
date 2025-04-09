using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LojaProdutos.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Foto { get; set; } = string.Empty;
        public double Valor { get; set; } = 0;
        public int QuantidadeEstoque { get; set; } = 0;
        public int CategoriaModelId { get; set; }
        [ValidateNever]
        public CategoriaModel Categoria { get; set; }

    }
}
