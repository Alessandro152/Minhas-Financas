using MinhasFinancas.Domain.Core.Shared;
using MinhasFinancas.Domain.ValueObjects;
using System;

namespace MinhasFinancas.Domain.Entidades
{
    public class Usuario : Base
    {
        //EF
        public Usuario()
        {

        }

        public Usuario(Guid id, string nome, LoginVO login)
        {
            Id = id;
            Nome = nome;
            Login = login;
        }

        public string Nome { get; private set; }

        public LoginVO Login { get; private set; }
    }
}
