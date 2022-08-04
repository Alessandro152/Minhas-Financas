using FluentResults;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.Application.QueryStack.Enum;
using MinhasFinancas.Application.QueryStack.ViewModel;
using MinhasFinancas.Domain.Financas.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.AppServices
{
    public class MinhasFinancasAppServiceHandler : IMinhasFinancasAppService
    {
        private readonly IBusHandler _bus;
        private readonly IMovimentoFinanceiroQueryRepository _queryHandler;

        public MinhasFinancasAppServiceHandler(IBusHandler bus, IMovimentoFinanceiroQueryRepository queryHandler)
        {
            _bus = bus;
            _queryHandler = queryHandler;
        }

        public async Task<IEnumerable<MovimentoFinanceiroViewModel>> AllDespesas(DateTime data)
            => await _queryHandler.GetAll(data, (int)ETipo.Desconto).ConfigureAwait(false);

        public async Task<IEnumerable<MovimentoFinanceiroViewModel>> AllReceitas(DateTime data)
            => await _queryHandler.GetAll(data, (int)ETipo.Provento).ConfigureAwait(false);

        public async Task<Result> AtualizarMovimentoFinanceiro(MovimentoFinanceiroViewModel dados)
        {
            var command = new UpdateMovimentoFinanceiroCommand(dados.Id, dados.Valor, dados.Titulo, dados.Data, dados.Tipo, dados.ClienteId);
            return await _bus.SendCommand<Result, UpdateMovimentoFinanceiroCommand>(command);
        }

        public async Task<Result> GravarMovimentoFinanceiro(MovimentoFinanceiroViewModel dados)
        {
            var command = new NewMovimentoFinanceiroCommand(dados.Valor, dados.Titulo, dados.Data, dados.Tipo, dados.ClienteId);
            return await _bus.SendCommand<Result, NewMovimentoFinanceiroCommand>(command).ConfigureAwait(false);
        }

        public async Task<bool> ExcluirMovimentoFinanceiro(IEnumerable<Guid> id)
        {
            try
            {
                return await _queryHandler.ExcluirMovimento(id).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ExcluirMovimentoFinanceiro(DateTime data)
        {
            try
            {
                return await _queryHandler.ExcluirMovimento(data).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
