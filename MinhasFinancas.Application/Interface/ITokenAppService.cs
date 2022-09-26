using MinhasFinancas.ViewModel.ViewModels;

namespace MinhasFinancas.Application.Interface
{
    public interface ITokenAppService
    {
        string GenerateToken(UsuarioViewModel login);
    }
}
