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
    public class MinhasFinancasAppService : IMinhasFinancasAppService
    {
        private readonly IBusHandler _bus;
        private readonly IMovimentoFinanceiroQueryRepository _movimentoFinanceiroQueryRepository;

        public MinhasFinancasAppService(IBusHandler bus, IMovimentoFinanceiroQueryRepository queryHandler)
        {
            _bus = bus;
            _movimentoFinanceiroQueryRepository = queryHandler;
        }

        public async Task<IEnumerable<MovimentoFinanceiroViewModel>> GetAllDespesas(DateTime data)
            => await _movimentoFinanceiroQueryRepository.GetAll(data, (int)TipoMovimentoEnum.Despesa);

        public async Task<IEnumerable<MovimentoFinanceiroViewModel>> GetAllReceitas(DateTime data)
            => await _movimentoFinanceiroQueryRepository.GetAll(data, (int)TipoMovimentoEnum.Receita);

        public async Task<Result<bool>> AtualizarMovimentoFinanceiro(UpdateMovimentoFinanceiroViewModel request)
        {
            try
            {
                var command = new UpdateMovimentoFinanceiroCommand(request.Id, 
                                                                   request.Valor, 
                                                                   request.Titulo, 
                                                                   request.Data, 
                                                                   request.Tipo, 
                                                                   request.ClienteId);
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
                                                                request.ClienteId);
                var result = await _bus.SendCommand(command);

                return result.ToResult<MovimentoFinanceiroViewModel>();
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
                return await _movimentoFinanceiroQueryRepository.ExcluirMovimento(id);
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
                return await _movimentoFinanceiroQueryRepository.ExcluirMovimento(data);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
