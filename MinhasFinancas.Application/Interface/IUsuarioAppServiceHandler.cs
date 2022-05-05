using MinhasFinancas.Application.QueryStack.ViewModel;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Interface
{
    public interface IUsuarioAppServiceHandler
    {
        Task<bool> CadastrarUsuario(UsuarioViewModel usuario);

        Task<UsuarioViewModel> Login(LoginViewModel dados);
    }
}
