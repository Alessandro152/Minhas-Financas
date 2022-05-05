using MinhasFinancas.Application.QueryStack.ViewModel;

namespace MinhasFinancas.Application.Interface
{
    public interface ITokenService
    {
        string GenerateToken(UsuarioViewModel login);
    }
}
