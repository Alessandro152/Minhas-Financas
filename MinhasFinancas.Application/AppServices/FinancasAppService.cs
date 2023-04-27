using FluentResults;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.Domain.Enum;
using MinhasFinancas.Domain.Financas.Commands;
using MinhasFinancas.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.AppServices
{
    public class FinancasAppService : IFinancasAppService
    {
        private readonly IBusHandler _bus;
        private readonly IFinancasQueryRepository _financasQueryRepository;

        public FinancasAppService(IBusHandler bus, IFinancasQueryRepository movimentoFinanceiroQueryRepository)
        {
            _bus = bus;
            _financasQueryRepository = movimentoFinanceiroQueryRepository;
        }

        public async Task<IAsyncEnumerable<MovimentoFinanceiroViewModel>> GetAllDespesas(DateTime data)
            => await Task.FromResult(_financasQueryRepository.GetAll(data, (int)TipoMovimentoEnum.Despesa));

        public async Task<IAsyncEnumerable<MovimentoFinanceiroViewModel>> GetAllReceitas(DateTime data)
            => await Task.FromResult(_financasQueryRepository.GetAll(data, (int)TipoMovimentoEnum.Receita));

        public async Task<Result<bool>> AtualizarMovimentoFinanceiro(Guid idMovimentoFinanceiro, UpdateMovimentoFinanceiroViewModel request)
        {
            try
            {
                var command = new UpdateMovimentoFinanceiroCommand(idMovimentoFinanceiro, 
                                                                   request.Valor, 
                                                                   request.Titulo, 
                                                                   request.Data, 
                                                                   request.Tipo);
                var result = await _bus.SendCommand(command);

                return result.ToResult<bool>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Result<MovimentoFinanceiroViewModel>> GravarMovimentoFinanceiro(NewMovimentoFinanceiroViewModel request)
        {
            try
            {
                var command = new NewMovimentoFinanceiroCommand(request.Valor, 
                                                                request.Titulo, 
                                                                request.Data, 
                                                                (TipoMovimentoEnum)request.Tipo, 
                                                                Guid.Empty);
                var result = await _bus.SendCommand(command);

                return result.ToResult<MovimentoFinanceiroViewModel>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IAsyncEnumerable<MovimentoFinanceiroViewModel>> GetAllFinancas(Guid usuarioId)
            => await Task.FromResult(_financasQueryRepository.GetAllFinancas(usuarioId));
    }
}
