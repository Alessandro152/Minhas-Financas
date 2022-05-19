using MinhasFinancas.Domain.Core.Shared;
using MinhasFinancas.Domain.ValueObjects;
using System;

namespace MinhasFinancas.Domain.Entidades
{
    public class Usuario : Base
    {
        public Usuario()
        {

        }

        public Usuario(string nome, string email, string password)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            LoginVO = new LoginVO
            {
                Email = email,
                Password = password
            };
        }

        public Usuario(Guid id, string nome, string email, string password)
        {
            Id = id;
            Nome = nome;
            LoginVO = new LoginVO
            {
                Email = email,
                Password = password
            };
        }

        public string Nome { get; private set; }

        public LoginVO LoginVO { get; set; }
    }
}
