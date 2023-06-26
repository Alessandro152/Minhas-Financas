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
            CreateMap<UsuarioLogin, UsuarioViewModel>()
                .ForMember(vm => vm.Id, x => x.MapFrom(a => a.Id))
                .ForMember(vm => vm.Nome, x => x.MapFrom(a => a.Usuario.Nome))
                .ForMember(vm => vm.Email, x => x.MapFrom(a => a.Email));
        }
    }
}
