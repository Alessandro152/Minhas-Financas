using FluentResults;
using FluentValidation.Results;
using MediatR;
using MinhasFinancas.Domain.Commands.Abstract;
using MinhasFinancas.Domain.Commands.Usuarios.Validations;
using MinhasFinancas.Domain.Core.Shared;
using System;

namespace MinhasFinancas.Domain.Commands.Usuarios
{
    public class UpdateUsuarioCommand : UsuarioCommand, IRequest<Result<Entidade>>
    {
        public UpdateUsuarioCommand(Guid usuarioId, string nome, string email)
        {
            UsuarioId = usuarioId;
            Nome = nome;
            Email = email;
        }

        public ValidationResult IsValid()
        {
            return new UpdateUsuarioValidation().Validate(this);
        }
    }
}
