using FluentValidation;
using MinhasFinancas.Domain.Cliente.Commands;
using MinhasFinancas.Domain.Resources;

namespace MinhasFinancas.Domain.Cliente.Validations
{
    public class UsuarioValidation : AbstractValidator<NewUsuarioCommand>
    {
        public UsuarioValidation()
        {
            Validate();
        }

        private void Validate()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(50)
                .WithMessage(DomainResource.UsuarioNomeValidationError);

            RuleFor(c => c.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .WithMessage(DomainResource.UsuarioEmailValidationError);

            RuleFor(c => c.PassWord)
                .NotEmpty()
                .NotNull()
                .MinimumLength(6)
                .MaximumLength(6)
                .WithMessage(DomainResource.UsuarioSenhaValidationError);

        }
    }
}
