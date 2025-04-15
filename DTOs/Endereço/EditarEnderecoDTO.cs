﻿namespace LojaProdutos.DTOs.Endereço
{
    public class EditarEnderecoDTO
    {
        public int Id { get; set; }
        public string Bairro { get; set; }
        public string Logradour { get; set; }
        public string Numero { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string? Complemento { get; set; }
        public int UsuarioModelId { get; set; }
    }
}
