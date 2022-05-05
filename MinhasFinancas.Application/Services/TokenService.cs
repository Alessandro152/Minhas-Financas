using MinhasFinancas.Application.Interface;
using MinhasFinancas.Application.QueryStack.ViewModel;
using System;

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
        {
            try
            {
                return _tokenBuilder.GenerateToken(login);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
