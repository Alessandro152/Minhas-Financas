using MinhasFinancas.Application.QueryStack.ViewModel;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Interface
{
    public interface IUsuarioAppServiceHandler
    {
        Task<dynamic> CadastrarUsuario(CadastroViewModel usuario);

        Task<UsuarioViewModel> Login(LoginViewModel dados);

        Task<ResultViewModel> AlterarCadastroUsuario(CadastroViewModel dados);
    }
}
