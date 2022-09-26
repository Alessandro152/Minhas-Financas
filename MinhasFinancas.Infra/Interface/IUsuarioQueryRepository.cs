using MinhasFinancas.ViewModel.ViewModels;
using System.Threading.Tasks;

namespace MinhasFinancas.Infra.Interface
{
    public interface IUsuarioQueryRepository
    {
        Task<UsuarioViewModel> Logar(LoginViewModel login);

        Task<bool> GetLogin(string email, string passWord);

        Task<bool> Get(string email);
    }
}
