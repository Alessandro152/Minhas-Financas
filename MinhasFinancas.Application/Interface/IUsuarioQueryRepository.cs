using MinhasFinancas.ViewModel.ViewModels;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Interface
{
    public interface IUsuarioQueryRepository
    {
        Task<UsuarioViewModel> Login(LoginViewModel login);
        Task<UsuarioViewModel> GetUsuarioByEmail(string email);
        Task<UsuarioViewModel> GetById(int usuarioId);
    }
}
