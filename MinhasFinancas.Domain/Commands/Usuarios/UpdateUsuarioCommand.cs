using FluentResults;
using FluentValidation.Results;
using MediatR;
using MinhasFinancas.Domain.Commands.Abstract;
using MinhasFinancas.Domain.Commands.Usuarios.Validations;
using System;

namespace MinhasFinancas.Domain.Commands.Usuarios
{
    public class UpdateUsuarioCommand : UsuarioCommand, IRequest<Result<bool>>
    {
        public UpdateUsuarioCommand(int usuarioId, string nome, string email)
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
