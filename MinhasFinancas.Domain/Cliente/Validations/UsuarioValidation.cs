using FluentValidation;
using MinhasFinancas.Domain.Cliente.Commands;
using MinhasFinancas.Domain.Resources;

namespace MinhasFinancas.Domain.Cliente.Validations
{
    public class UsuarioValidation : AbstractValidator<NewUsuarioCommand>
    {
        public UsuarioValidation()
        {
        }

        public void Validate()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(50)
                .WithMessage(DomainResource.UsuarioNomeValidationError);
        }
    }
}
