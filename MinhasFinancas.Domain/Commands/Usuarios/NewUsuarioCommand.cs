using FluentResults;
using FluentValidation.Results;
using MediatR;
using MinhasFinancas.Domain.Commands.Abstract;
using MinhasFinancas.Domain.Commands.Usuarios.Validations;
using MinhasFinancas.Domain.Core.Shared;

namespace MinhasFinancas.Domain.Commands.Usuarios
{
    public class NewUsuarioCommand : UsuarioCommand, IRequest<Result<Entidade>>
    {
        public NewUsuarioCommand(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public ValidationResult IsValid()
            => new NewUsuarioValidation().Validate(this);
    }
}
