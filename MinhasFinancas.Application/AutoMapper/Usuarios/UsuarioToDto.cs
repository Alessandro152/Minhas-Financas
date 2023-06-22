using AutoMapper;
using MinhasFinancas.Domain.Entidades.Usuarios;
using MinhasFinancas.ViewModel.ViewModels;

namespace MinhasFinancas.Application.AutoMapper.Usuarios
{
    public class UsuarioToDto : Profile
    {
        public UsuarioToDto()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
        }
    }
}
