using FluentResults;
using MediatR;
using MinhasFinancas.Domain.Core.Shared;
using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Domain.Financas.Commands;
using MinhasFinancas.Domain.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MinhasFinancas.Domain.Handlers.Financas
{
    public class MovimentoFinanceiroHandler : IRequestHandler<NewMovimentoFinanceiroCommand, Result<Entidade>>,
                                              IRequestHandler<UpdateMovimentoFinanceiroCommand, Result<Entidade>>
    {
        private readonly IMovimentoFinanceiroRepository _financasRepositorio;

        public MovimentoFinanceiroHandler(IMovimentoFinanceiroRepository financasRepositorio)
        {
            _financasRepositorio = financasRepositorio;
        }

        public async Task<Result<Entidade>> Handle(NewMovimentoFinanceiroCommand request, CancellationToken cancellationToken)
        {
            if (request is null) return default;

            var entity = new MovimentoFinanceiro(request.Valor, 
                                                 request.Descricao, 
                                                 request.Data, 
                                                 request.Tipo, 
                                                 request.UsuarioId);

             _financasRepositorio.Add(entity);

            return entity;
        }

        public async Task<Result<Entidade>> Handle(UpdateMovimentoFinanceiroCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
