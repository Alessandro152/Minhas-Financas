using MediatR;
using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Domain.Financas.Commands;
using MinhasFinancas.Domain.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MinhasFinancas.Domain.Financas.Handlers
{
    public class MovimentoFinanceiroHandler : IRequestHandler<NewMovimentoFinanceiroCommand, bool>, IRequestHandler<UpdateMovimentoFinanceiroCommand, bool>
    {
        private readonly IMovimentoFinanceiroRepository _financasRepositorio;

        public MovimentoFinanceiroHandler(IMovimentoFinanceiroRepository financasRepositorio)
        {
            _financasRepositorio = financasRepositorio;
        }

        public async Task<bool> Handle(NewMovimentoFinanceiroCommand request, CancellationToken cancellationToken)
        {
            if (request is null) return false;

            try
            {

                var entity = new MovimentoFinanceiro(request.Valor, request.Titulo, request.Data, request.Tipo, request.ClienteId);

                var result = await _financasRepositorio.GravarMovimentoFinanceiro(entity).ConfigureAwait(false);

                if (!result)
                {
                    //TODO - Implementar domain notification
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> Handle(UpdateMovimentoFinanceiroCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
