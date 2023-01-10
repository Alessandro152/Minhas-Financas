using MinhasFinancas.Domain.Core.Shared;
using System;
using System.Collections.Generic;

namespace MinhasFinancas.Domain.Entidades
{
    public class Login : Entidade
    {
        protected Login()
        {

        }

        public Login(Guid id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }

        public string Email { get; }
        public string Password { get; }

        //Relacionamento
        public Guid UsuarioId { get; private set; }
        public Usuario Usuario { get; private set; }
    }
}
