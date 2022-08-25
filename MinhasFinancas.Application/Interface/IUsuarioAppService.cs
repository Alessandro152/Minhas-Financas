using FluentResults;
using MinhasFinancas.Application.QueryStack.ViewModel;
using System;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Interface
{
    public interface IUsuarioAppService
    {
        Task<Result> CadastrarUsuario(NewCadastroViewModel usuario);

        Task<UsuarioCredencialViewModel> Login(LoginViewModel dados);

        Task<Result> AlterarCadastroUsuario(Guid id, NewCadastroViewModel dados);
    }
}
