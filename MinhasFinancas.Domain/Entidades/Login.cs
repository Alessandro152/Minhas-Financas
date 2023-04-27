using MinhasFinancas.Domain.Core.Shared;
using System;

namespace MinhasFinancas.Domain.Entidades
{
    public class Login : Entidade
    {
        protected Login(){}

        public Login(Guid id, string email, string password, Guid usuarioId)
        {
            Id = id;
            Email = email;
            Password = password;
            UsuarioId = usuarioId;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }
        public Guid UsuarioId { get; private set; }
        public virtual Usuario Usuario { get; private set; }
    }
}
