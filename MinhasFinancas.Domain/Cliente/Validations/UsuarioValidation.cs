using FluentValidation;
using MinhasFinancas.Domain.Cliente.Commands;
using MinhasFinancas.Domain.Resources;

namespace MinhasFinancas.Domain.Cliente.Validations
{
    public class UsuarioValidation : AbstractValidator<NewUsuarioCommand>
    {
        public UsuarioValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(50)
                .WithMessage(DomainResource.UsuarioNomeValidationError);

            RuleFor(c => c.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .WithMessage(DomainResource.UsuarioEmailValidationError);

            RuleFor(c => c.PassWord)
                .NotNull()
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(6)
                .WithMessage(DomainResource.UsuarioSenhaValidationError);
        }
    }
}
