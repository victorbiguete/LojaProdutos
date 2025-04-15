using System.ComponentModel.DataAnnotations;

namespace LojaProdutos.DTOs.Login
{
    public class LoginUsuarioDTO
    {
        [Required(ErrorMessage = "Digite seu Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite sua Senha")]
        public string Senha { get; set; }
    }
}
