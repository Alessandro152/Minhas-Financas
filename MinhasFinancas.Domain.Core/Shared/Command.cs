using FluentResults;
using MediatR;

namespace MinhasFinancas.Domain.Core.Shared
{
    public abstract class Command : IRequest<Result>
    {
    }
}
