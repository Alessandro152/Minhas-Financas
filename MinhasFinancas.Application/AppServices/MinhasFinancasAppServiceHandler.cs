using MinhasFinancas.Application.Interface;
using MinhasFinancas.Application.QueryStack.Enum;
using MinhasFinancas.Application.QueryStack.ViewModel;
using MinhasFinancas.Domain.Financas.Commands;
using MinhasFinancas.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.AppServices
{
    public class MinhasFinancasAppServiceHandler : IMinhasFinancasAppServiceHandler
    {
        private readonly IBusHandler _bus;
        private readonly IMovimentoFinanceiroQueryHandler _queryHandler;
        private readonly IApplicationAdapter _adapter;

        public MinhasFinancasAppServiceHandler(IBusHandler bus, IMovimentoFinanceiroQueryHandler queryHandler, IApplicationAdapter adapter)
        {
            _bus = bus;
            _queryHandler = queryHandler;
            _adapter = adapter;
        }

        public async Task<IEnumerable<MovimentoFinanceiroViewModel>> AllDespesas(DateTime data)
        {
            try
            {
                return await _queryHandler.GetAll(data, (int)ETipo.Desconto).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<MovimentoFinanceiroViewModel>> AllReceitas(DateTime data)
        {
            try
            {
                return await _queryHandler.GetAll(data, (int)ETipo.Provento).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResultViewModel> AtualizarMovimentoFinanceiro(MovimentoFinanceiroViewModel dados)
        {
            try
            {
                var command = new UpdateMovimentoFinanceiroCommand(dados.Id, dados.Valor, dados.Titulo, dados.Data, dados.Tipo, dados.ClienteId);
                _bus.SendCommand(command);
                return default;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResultViewModel> GravarMovimentoFinanceiro(MovimentoFinanceiroViewModel dados)
        {
            try
            {
                var command = new NewMovimentoFinanceiroCommand(dados.Valor, dados.Titulo, dados.Data, dados.Tipo, dados.ClienteId);
                var result = await _bus.SendCommand<bool, NewMovimentoFinanceiroCommand>(command).ConfigureAwait(false);

                return _adapter.RetornarDomainResult(result);
            }
            catch (Exception)
            {
                throw;
            }
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
