using FluentResults;
using MinhasFinancas.Application.QueryStack.ViewModel;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Interface
{
    public interface IUsuarioAppService
    {
        Task<Result> CadastrarUsuario(CadastroViewModel usuario);

        Task<UsuarioViewModel> Login(LoginViewModel dados);

        Task<Result> AlterarCadastroUsuario(CadastroViewModel dados);
    }
}
