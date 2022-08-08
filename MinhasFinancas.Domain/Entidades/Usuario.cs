using MinhasFinancas.Domain.Core.Shared;
using MinhasFinancas.Domain.Core.ValueObjects;
using System;

namespace MinhasFinancas.Domain.Entidades
{
    public class Usuario : Base
    {
        //EF
        public Usuario()
        {

        }

        public Usuario(Guid id, string nome, EnderecoVO endereco, LoginVO login)
        {
            Id = id;
            Nome = nome;
            Endereco = endereco;
            Login = login;
        }

        public string Nome { get; private set; }

        public EnderecoVO Endereco { get; private set; }

        public LoginVO Login { get; private set; }
    }
}
