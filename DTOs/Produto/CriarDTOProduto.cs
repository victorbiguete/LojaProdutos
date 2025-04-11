using LojaProdutos.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace LojaProdutos.DTOs.Produto
{
    public class CriarDTOProduto
    {
        [Required(ErrorMessage ="Digite um Nome")]
        
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage ="Digite a Marca")]
        public string Marca { get; set; } = string.Empty;

        [Required(ErrorMessage ="Insira uma Foto")]
        public string Foto { get; set; } = string.Empty;

        [Required(ErrorMessage ="Digite um Valor")]
        [MinLength(1)]
        public double Valor { get; set; } = 0;

        [Required(ErrorMessage ="Digite uma Quantidade")]
        [MinLength(1)]
        public int QuantidadeEstoque { get; set; } = 0;

        [Required(ErrorMessage ="Selecione uma Categoria")]
        public int CategoriaModelId { get; set; }
        
    }
}
