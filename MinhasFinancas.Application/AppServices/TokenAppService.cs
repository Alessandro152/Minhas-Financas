using MinhasFinancas.Application.Interface;
using MinhasFinancas.Application.QueryStack.ViewModel;
using MinhasFinancas.ViewModel.ViewModels;

namespace MinhasFinancas.Application.Services
{
    public class TokenAppService : ITokenAppService
    {
        private readonly ITokenBuilder _tokenBuilder;

        public TokenAppService(ITokenBuilder tokenBuilder)
        {
            _tokenBuilder = tokenBuilder;
        }

        public string GenerateToken(UsuarioViewModel login)
            => _tokenBuilder.GenerateToken(login);
    }
}
