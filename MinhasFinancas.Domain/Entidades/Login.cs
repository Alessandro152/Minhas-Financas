using MinhasFinancas.Domain.Core.Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhasFinancas.Domain.Entidades
{
    public class Login : Base
    {
        public Login()
        {

        }

        public Login(string email, string password, Guid clienteId)
        {
            Id = Guid.NewGuid();
            EMail = email;
            PassWord = password;
            ClienteId = clienteId;
        }

        public string EMail { get; private set; }

        public string PassWord { get; private set; }

        [ForeignKey("clienteId")]
        public Guid ClienteId { get; private set; }
    }
}
