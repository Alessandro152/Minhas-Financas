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

        public Usuario(string nome, LoginVO login)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Login = login;
        }

        public Usuario(Guid id, string nome, LoginVO login)
        {
            Id = id;
            Nome = nome;
            Login = login;
        }

        public string Nome { get; private set; }

        public LoginVO Login { get; set; }
    }
}
