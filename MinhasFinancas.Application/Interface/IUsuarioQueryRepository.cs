using MinhasFinancas.Application.QueryStack.ViewModel;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Interface
{
    public interface IUsuarioQueryRepository
    {
        Task<UsuarioViewModel> Logar(LoginViewModel login);
    }
}
