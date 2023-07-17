using Microsoft.IdentityModel.Tokens;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.Application.Services;
using MinhasFinancas.ViewModel.ViewModels;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MinhasFinancas.Infra.Builders
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
            //Transformo minha hash secret em bytes através da codificação ASCII
            var key = Encoding.ASCII.GetBytes(Setting.Secret);

            //Utilizo o método CreateToken para definir meu subject, expire e signing credential
            var token = _tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                //Onde defino minhas claims, ou seja, minhas clausulas para autorização, quais parametros serão utilizados 
                //para autorização. Neste caso, nome do usuário e e-mail
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Email, usuario.Email)
                }),

                //Duração do token a partir de sua geração
                Expires = DateTime.UtcNow.AddHours(2),

                //Assinatura criptografada com chave simétrica e utilizando algortimo SH256
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            //Após criado o token, o mesmo é escrito, ou seja, criado o payload. É possível consultá-lo no site do JWT
            return _tokenHandler.WriteToken(token);
        }
    }
}
