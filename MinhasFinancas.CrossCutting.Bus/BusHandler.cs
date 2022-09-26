using FluentResults;
using MediatR;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.Domain.Core.Shared;
using System.Threading.Tasks;

namespace MinhasFinancas.CrossCutting.Bus
{
    public sealed class BusHandler : IBusHandler
    {
        private readonly IMediator _mediator;

        public BusHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Result<Entidade>> SendCommand<TCommand>(TCommand message) where TCommand : IRequest<Result<Entidade>>
            => await _mediator.Send(message);

        public async Task<Result<bool>> SendCommand<TCommand, TResult>(TCommand message) where TCommand : IRequest<Result<bool>>
            => await _mediator.Send(message);
    }
}
