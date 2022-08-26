using FluentResults;
using FluentValidation.Results;
using MediatR;
using MinhasFinancas.Domain.Cliente.Validations;
using MinhasFinancas.Domain.Commands.Abstract;
using MinhasFinancas.Domain.Core.Shared;

namespace MinhasFinancas.Domain.Commands.Usuarios
{
    public class NewUsuarioCommand : UsuarioCommand, IRequest<Result<Entidade>>
    {
        public NewUsuarioCommand(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public ValidationResult IsValid()
        {
            return new NewUsuarioValidation().Validate(this);
        }
    }
}
