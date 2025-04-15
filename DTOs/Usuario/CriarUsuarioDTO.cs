using LojaProdutos.Enums;
using System.ComponentModel.DataAnnotations;

namespace LojaProdutos.DTOs.Usuario
{
    public class CriarUsuarioDTO
    {
        [Required(ErrorMessage = "Digite o Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Selecione o Cargo")]
        public CargoEnum Cargo { get; set; }

        [Required(ErrorMessage = "Digite o Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Digite o Logradouro")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Digite o Numero")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Digite o CEP")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Digite o Estado")]
        public string Estado { get; set; }
        
        public string? Complemento { get; set; }

        [Required(ErrorMessage = "Digite a senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Digite a Senha"),
         Compare("Senha", ErrorMessage = "As Senhas não coincidem")]
        public string ConfirmarSenha { get; set; }
    }
}
