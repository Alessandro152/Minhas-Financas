using FluentValidation;
using MinhasFinancas.Domain.Cliente.Commands;
using MinhasFinancas.Domain.Resources;
using System;

namespace MinhasFinancas.Domain.Cliente.Validations
{
    public class LoginValidation : AbstractValidator<NewLoginCommand>
    {
        public LoginValidation()
        {
        }

        public void Validate()
        {
            RuleFor(c => c.EMail)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .WithMessage(DomainResource.UsuarioEmailValidationError);

            RuleFor(c => c.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(6)
                .WithMessage(DomainResource.UsuarioSenhaValidationError);
        }
    }
}
