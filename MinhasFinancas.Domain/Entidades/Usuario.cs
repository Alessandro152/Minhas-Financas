using MinhasFinancas.Domain.Core.Shared;
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
            Email = email;
            PassWord = password;
        }

        public string Nome { get; private set; }

        public string Email { get; private set; }

        public string PassWord { get; private set; }
    }
}
