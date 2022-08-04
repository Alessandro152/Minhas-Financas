using System;

namespace MinhasFinancas.CrossCutting.Bus
{
    public class BusHandler : IBusHandler
    {
        public BusHandler()
        {

        }

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
