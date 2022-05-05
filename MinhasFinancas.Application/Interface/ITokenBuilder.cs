using MinhasFinancas.Application.QueryStack.ViewModel;

namespace MinhasFinancas.Application.Interface
{
    public interface ITokenBuilder
    {
        string GenerateToken(UsuarioViewModel login);
    }
}
