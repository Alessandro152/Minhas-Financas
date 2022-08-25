using FluentValidation.Results;
using MinhasFinancas.Domain.Commands.Abstract;
using MinhasFinancas.Domain.Commands.Usuarios.Validations;
using System;

namespace MinhasFinancas.Domain.Commands.Usuarios
{
    public class UpdateUsuarioCommand : UsuarioCommand
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
