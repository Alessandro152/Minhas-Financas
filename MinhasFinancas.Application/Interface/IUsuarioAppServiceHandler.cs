using MinhasFinancas.Application.QueryStack.ViewModel;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Interface
{
    public interface IUsuarioAppServiceHandler
    {
        Task<ResultViewModel> CadastrarUsuario(UsuarioViewModel usuario);

        Task<UsuarioViewModel> Login(LoginViewModel dados);

        Task<ResultViewModel> AlterarCadastroUsuario(UsuarioViewModel dados);
    }
}
