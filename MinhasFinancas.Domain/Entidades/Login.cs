using MinhasFinancas.Domain.Core.Shared;
using System;

namespace MinhasFinancas.Domain.Entidades
{
    public class Login : Entidade
    {
        protected Login()
        {

        }

        public Login(Guid id, string email, string password, Guid clienteId)
        {
            Id = id;
            EMail = email;
            PassWord = password;
            ClienteId = clienteId;
        }

        public string EMail { get; }

        public string PassWord { get; }

        public Guid ClienteId { get; }
    }
}
