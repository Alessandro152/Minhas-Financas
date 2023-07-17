using FluentResults;
using MediatR;
using MinhasFinancas.Domain.Core.Shared;
using MinhasFinancas.Domain.Entidades.Financas;
using MinhasFinancas.Domain.Financas.Commands;
using MinhasFinancas.Domain.Interface.Repositories;
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

            //TODO - Incluir validação de command
            //TODO - Validar se o usuário existe

            var entity = new MovimentoFinanceiro(request.Descricao,
                                                 request.DataVencimento,
                                                 request.Tipo,
                                                 request.UsuarioId);

            entity.AdicionarValores(request.Valor, request.Pago, request.Recebido);

            _financasRepositorio.Add(entity);

            return entity;
        }

        public async Task<Result<Entidade>> Handle(UpdateMovimentoFinanceiroCommand request, CancellationToken cancellationToken)
        {
            if (request is null) return default;

            //TODO - Incluir validação de command
            //TODO - Validar se o usuário existe
            //TODO - Ajustar edição

            var entity = new MovimentoFinanceiro(request.Descricao,
                                                 request.DataVencimento,
                                                 request.Tipo,
                                                 request.UsuarioId);

            return entity;
        }

        //TODO - Excluir um movimento financeiro
    }
}
