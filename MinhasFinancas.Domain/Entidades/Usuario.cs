using MinhasFinancas.Domain.Core.Shared;
using System;

namespace MinhasFinancas.Domain.Entidades
{
    public class Usuario : Entidade
    {
        protected Usuario(){}

        public Usuario(Guid id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public string Nome { get; }
        public string Email { get; }

        public Login Login { get; private set; }
    }
}
