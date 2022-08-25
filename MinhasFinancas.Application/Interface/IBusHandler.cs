using FluentResults;
using MinhasFinancas.Domain.Core.Shared;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Interface
{
    public interface IBusHandler
    {
        Task<Result> SendCommand<TCommand>(TCommand message) where TCommand : Command;

        Task<bool> SendCommand<TCommand, TResult>(TCommand message) where TCommand : Command;
    }
}
