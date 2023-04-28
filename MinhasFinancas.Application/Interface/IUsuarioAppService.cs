using FluentResults;
using MinhasFinancas.ViewModel.ViewModels;
using System;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Interface
{
    public interface IUsuarioAppService
    {
        Task<Result<UsuarioViewModel>> CadastrarUsuario(NewUsuarioViewModel usuario);

        Task<UsuarioCredencialViewModel> Login(LoginViewModel dados);

        Task<Result<bool>> AlterarCadastroUsuario(Guid id, UpdateUsuarioViewModel dados);
    }
}
