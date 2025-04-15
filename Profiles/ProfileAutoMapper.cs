using AutoMapper;
using LojaProdutos.DTOs.Endereço;
using LojaProdutos.Models;

namespace LojaProdutos.Profiles
{
    public class ProfileAutoMapper : Profile
    {
        public ProfileAutoMapper()
        {
            CreateMap<EnderecoModel, EditarEnderecoDTO>().ReverseMap();
        }
    }
}
