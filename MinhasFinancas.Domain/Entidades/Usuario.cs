using MinhasFinancas.Domain.Core.Shared;
using System;

namespace MinhasFinancas.Domain.Entidades
{
    public class Usuario : Entidade
    {
        protected Usuario(){}

        public Usuario(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public virtual Login Login { get; private set; }

        public void AddLogin(string email, string senha)
            => Login = new Login(email, senha, Id);

        public void Editar(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
    }
}
