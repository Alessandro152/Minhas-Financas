using FluentValidation.Results;
using MinhasFinancas.Domain.Cliente.Validations;
using MinhasFinancas.Domain.Core.Shared;
using System;

namespace MinhasFinancas.Domain.Cliente.Commands
{
    public class UpdateUsuarioCommand : Command
    {
        public UpdateUsuarioCommand(Guid clienteId, string nome, string email, string password)
        {
            ClienteId = clienteId;
            Nome = nome;
            Email = email;
            Password = password;
        }

        public Guid ClienteId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
