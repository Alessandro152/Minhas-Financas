using MediatR;
using MinhasFinancas.Domain.Core.Shared;
using MinhasFinancas.Domain.Interface;
using System.Threading.Tasks;

namespace MinhasFinancas.Infra.CrossCutting
{
    public class BusHandler : IBusHandler
    {
        private readonly IMediator _mediator;

        public BusHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void SendCommand<TCommand>(TCommand message) where TCommand : Command
        {
            _mediator.Send(message);
        }

        public async Task<dynamic> SendCommand<TResult, TCommand>(TCommand message) where TCommand : Command
        {
            return await _mediator.Send(message).ConfigureAwait(false);
        }
    }
}
