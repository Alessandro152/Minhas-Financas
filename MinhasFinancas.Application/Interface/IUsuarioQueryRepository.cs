using MinhasFinancas.Application.QueryStack.ViewModel;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Interface
{
    public interface IUsuarioQueryRepository
    {
        Task<UsuarioViewModel> Logar(LoginViewModel login);

        Task<bool> Get(string email);

        Task<bool> GetLogin(string email, string passWord);
    }
}
