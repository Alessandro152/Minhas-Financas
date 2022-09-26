using FluentValidation;
using MinhasFinancas.Domain.Commands.Abstract;

namespace MinhasFinancas.Domain.Commands.Financas.Validations
{
    public abstract class FinancasValidation<T> : AbstractValidator<T> where T : FinancasCommand
    {
    }
}
