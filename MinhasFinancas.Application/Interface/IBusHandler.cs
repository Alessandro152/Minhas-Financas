using FluentResults;
using MinhasFinancas.Domain.Core.Shared;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Interface
{
    public interface IBusHandler
    {
        void SendCommand<TCommand>(TCommand message) where TCommand : Command;

        Task<Result> SendCommand<TResult, TCommand>(TCommand message) where TCommand : Command;
    }
}
