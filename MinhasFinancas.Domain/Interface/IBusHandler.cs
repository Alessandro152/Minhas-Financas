using MinhasFinancas.Domain.Core.Shared;
using System.Threading.Tasks;

namespace MinhasFinancas.Domain.Interface
{
    public interface IBusHandler
    {
        void SendCommand<TCommand>(TCommand message) where TCommand : Command;

        Task<dynamic> SendCommand<TResult, TCommand>(TCommand message) where TCommand : Command;
    }
}
