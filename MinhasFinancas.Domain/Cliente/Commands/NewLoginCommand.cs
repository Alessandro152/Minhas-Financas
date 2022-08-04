using FluentValidation.Results;
using MinhasFinancas.Domain.Cliente.Validations;
using MinhasFinancas.Domain.Core.Shared;
using System;

namespace MinhasFinancas.Domain.Cliente.Commands
{
    public class NewLoginCommand : Command
    {
        public NewLoginCommand(string eMail, string passWord, Guid clienteId)
        {
            Id = Guid.NewGuid();
            EMail = eMail;
            Password = passWord;
            ClienteId = clienteId;
        }

        public Guid Id { get; }

        public string EMail { get; }

        public string Password { get; }

        public Guid ClienteId { get; }

        public ValidationResult IsValid()
        {
            return new LoginValidation().Validate(this);
        }
    }
}
