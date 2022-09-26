using MinhasFinancas.ViewModel.ViewModels;

namespace MinhasFinancas.Application.Interface
{
    public interface ITokenBuilder
    {
        string GenerateToken(UsuarioViewModel login);
    }
}
