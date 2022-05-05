using MediatR;
using MinhasFinancas.Domain.Core.Shared;
using MinhasFinancas.Domain.Interface;
using System;
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

        public async void SendCommand<TCommand>(TCommand message) where TCommand : Command
        {
            await _mediator.Send(message);
        }

        public async Task<bool> SendCommand<TResult, TCommand>(TCommand message) where TCommand : Command
        {
            var result = await _mediator.Send(message).ConfigureAwait(false);

            return Convert.ToBoolean(result);
        }
    }
}
