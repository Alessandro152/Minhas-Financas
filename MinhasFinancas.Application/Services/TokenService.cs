using MinhasFinancas.Application.Interface;
using MinhasFinancas.Application.QueryStack.ViewModel;

namespace MinhasFinancas.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly ITokenBuilder _tokenBuilder;

        public TokenService(ITokenBuilder tokenBuilder)
        {
            _tokenBuilder = tokenBuilder;
        }

        public string GenerateToken(UsuarioViewModel login)
            => _tokenBuilder.GenerateToken(login);
    }
}
