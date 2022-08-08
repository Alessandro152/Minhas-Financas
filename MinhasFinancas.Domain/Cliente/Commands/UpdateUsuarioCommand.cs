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

        public Guid ClienteId { get; }

        public string Nome { get; }

        public string Email { get; }

        public string Password { get; }
    }
}
