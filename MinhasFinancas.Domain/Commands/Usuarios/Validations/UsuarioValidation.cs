using FluentValidation;
using MinhasFinancas.Domain.Commands.Abstract;
using MinhasFinancas.Domain.Resources;

namespace MinhasFinancas.Domain.Commands.Usuarios.Validations
{
    public abstract class UsuarioValidation<T> : AbstractValidator<T> where T : UsuarioCommand
    {
        protected void ValidarId()
        {
            RuleFor(c => c.UsuarioId)
                .NotNull()
                .WithMessage("");
        }

        protected void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(50)
                .WithMessage(DomainResource.UsuarioNomeValidationError);
        }

        protected void ValidarEmail()
        {
            RuleFor(c => c.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .WithMessage(DomainResource.UsuarioEmailValidationError);
        }
    }
}
