using FluentResults;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.Application.QueryStack.Enum;
using MinhasFinancas.Application.QueryStack.ViewModel;
using MinhasFinancas.Domain.Enum;
using MinhasFinancas.Domain.Financas.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.AppServices
{
    public class MinhasFinancasAppService : IMinhasFinancasAppService
    {
        private readonly IBusHandler _bus;
        private readonly IMovimentoFinanceiroQueryRepository _movimentoFinanceiroQueryRepository;

        public MinhasFinancasAppService(IBusHandler bus, IMovimentoFinanceiroQueryRepository queryHandler)
        {
            _bus = bus;
            _movimentoFinanceiroQueryRepository = queryHandler;
        }

        public async Task<IEnumerable<UpdateMovimentoFinanceiroViewModel>> AllDespesas(DateTime data)
            => await _movimentoFinanceiroQueryRepository.GetAll(data, (int)ETipo.Desconto).ConfigureAwait(false);

        public async Task<IEnumerable<UpdateMovimentoFinanceiroViewModel>> AllReceitas(DateTime data)
            => await _movimentoFinanceiroQueryRepository.GetAll(data, (int)ETipo.Provento).ConfigureAwait(false);

        public async Task<Result> AtualizarMovimentoFinanceiro(UpdateMovimentoFinanceiroViewModel request)
        {
            try
            {
                var command = new UpdateMovimentoFinanceiroCommand(request.Id, request.Valor, request.Titulo, request.Data, (TipoFinanceiroEnum)request.Tipo, request.ClienteId);
                var result = await _bus.SendCommand(command);

                return result.ToResult();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Result> GravarMovimentoFinanceiro(NewMovimentoFinanceiroViewModel request)
        {
            try
            {
                var command = new NewMovimentoFinanceiroCommand(request.Valor, request.Titulo, request.Data, (TipoFinanceiroEnum)request.Tipo, request.ClienteId);
                var result = await _bus.SendCommand(command);

                return result.ToResult();
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
                return await _movimentoFinanceiroQueryRepository.ExcluirMovimento(id).ConfigureAwait(false);
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
                return await _movimentoFinanceiroQueryRepository.ExcluirMovimento(data).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
