﻿using LojaProdutos.Data;
using LojaProdutos.DTOs.Usuario;
using LojaProdutos.Models;
using LojaProdutos.Services.AutenticaçãoService;
using Microsoft.EntityFrameworkCore;

namespace LojaProdutos.Services.Usuario
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly AppDbContext _context;
        private readonly IAutenticacaoInterface _autenticacaoInterface;
        public UsuarioService(AppDbContext context, IAutenticacaoInterface autenticacaoInterface)
        {
            _context = context;
            _autenticacaoInterface = autenticacaoInterface;
        }
        public async Task<UsuarioModel> BuscarUsuarioPorId(int id)
        {
            try
            {
                return await _context.Usuarios.Include(e => e.Endereco)
                                                     .Where(u => u.Id == id)
                                                     .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<UsuarioModel>> BuscarUsuarios()
        {
            try
            {
                return await _context.Usuarios.Include(x => x.Endereco).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<CriarUsuarioDTO> Cadastrar(CriarUsuarioDTO criarUsuarioDTO)
        {
            try
            {
                _autenticacaoInterface.CriarSenhaHash(criarUsuarioDTO.Senha, out byte[] senhaHash, out byte[] senhaSalt);

                var usuario = new UsuarioModel
                {
                    Cargo = criarUsuarioDTO.Cargo,
                    Email = criarUsuarioDTO.Email,
                    Nome = criarUsuarioDTO.Nome,
                    SenhaHash = senhaHash,
                    SenhaSalt = senhaSalt
                };

                var endereco = new EnderecoModel
                {
                    Logradour = criarUsuarioDTO.Logradouro,
                    Bairro = criarUsuarioDTO.Bairro,
                    CEP = criarUsuarioDTO.CEP,
                    Complemento = criarUsuarioDTO.Complemento,
                    Estado = criarUsuarioDTO.Estado,
                    Numero = criarUsuarioDTO.Numero,
                    Usuario = usuario
                };

                usuario.Endereco = endereco;
                _context.Add(usuario);
                await _context.SaveChangesAsync();

                return criarUsuarioDTO;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> VerificaSeExisteEmail(CriarUsuarioDTO criarUsuarioDTO)
        {
            try
            {
                var usuario = await _context.Usuarios.Where(x => x.Email.Equals(criarUsuarioDTO.Email)).FirstOrDefaultAsync();

                if(usuario == null)
                    return false;

                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
