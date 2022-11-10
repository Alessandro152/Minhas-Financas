using FluentResults;
using FluentValidation.Results;
using MediatR;
using System;

namespace MinhasFinancas.Domain.Cliente.Commands
{
    public class NewUsuarioLoginCommand : IRequest<Result>
    {
        public NewUsuarioLoginCommand(string eMail, string passWord, Guid clienteId)
        {
            EMail = eMail;
            Password = passWord;
            ClienteId = clienteId;
        }

        public string EMail { get; }

        public string Password { get; }

        public Guid ClienteId { get; }
    }
}
