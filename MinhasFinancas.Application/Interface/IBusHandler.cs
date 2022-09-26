using FluentResults;
using MediatR;
using MinhasFinancas.Domain.Core.Shared;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Interface
{
    public interface IBusHandler
    {
        Task<Result<Entidade>> SendCommand<TCommand>(TCommand message) where TCommand : IRequest<Result<Entidade>>;

        Task<Result<bool>> SendCommand<TCommand, TResult>(TCommand message) where TCommand : IRequest<Result<bool>>;
    }
}
