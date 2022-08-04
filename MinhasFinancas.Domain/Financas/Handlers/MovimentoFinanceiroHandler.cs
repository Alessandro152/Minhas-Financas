using FluentResults;
using MediatR;
using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Domain.Financas.Commands;
using MinhasFinancas.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MinhasFinancas.Domain.Financas.Handlers
{
    public class MovimentoFinanceiroHandler : IRequestHandler<NewMovimentoFinanceiroCommand, Result>, 
                                              IRequestHandler<UpdateMovimentoFinanceiroCommand, Result>
    {
        private readonly IMovimentoFinanceiroRepository _financasRepositorio;

        public MovimentoFinanceiroHandler(IMovimentoFinanceiroRepository financasRepositorio)
        {
            _financasRepositorio = financasRepositorio;
        }

        public async Task<Result> Handle(NewMovimentoFinanceiroCommand request, CancellationToken cancellationToken)
        {
            if (request is null) return new Result { HasError = true, ErrorMessage = new List<string> { "Command nula" } };

            try
            {

                var entity = new MovimentoFinanceiro(request.Valor, request.Titulo, request.Data, request.Tipo, request.ClienteId);

                var result = await _financasRepositorio.GravarMovimentoFinanceiro(entity).ConfigureAwait(false);

                if (!result)
                {
                    //TODO - Implementar domain notification
                }

                return new Result { HasError = false };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Result> Handle(UpdateMovimentoFinanceiroCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
