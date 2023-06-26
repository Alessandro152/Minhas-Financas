using MinhasFinancas.ViewModel.ViewModels;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Interface
{
    public interface ILoginAppService
    {
        Task<UsuarioLoginViewModel> Login(LoginViewModel request);
    }
}
