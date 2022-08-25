using Microsoft.IdentityModel.Tokens;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.Application.QueryStack.ViewModel;
using MinhasFinancas.Application.Services;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MinhasFinancas.Application.Builders
{
    public class TokenBuilder : ITokenBuilder
    {
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public TokenBuilder()
        {
            _tokenHandler = new JwtSecurityTokenHandler();
        }

        public string GenerateToken(UsuarioViewModel usuario)
        {
            var key = Encoding.ASCII.GetBytes(Setting.Secret);

            var token = _tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                        new Claim(ClaimTypes.Name, usuario.Id.ToString()),
                        new Claim(ClaimTypes.Name, usuario.Nome),
                        new Claim(ClaimTypes.Email, usuario.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            return _tokenHandler.WriteToken(token);
        }
    }
}
