using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.ViewModel.ViewModels;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Interface
{
    public interface IUsuarioQueryRepository
    {
        Task<UsuarioViewModel> Logar(LoginViewModel login);
        Task<bool> GetLogin(string email, string passWord);
        Task<Usuario> GetUsuario(string email);
        Task<Usuario> GetUsuarioById(int usuarioId);
    }
}
