using FluentResults;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.Domain.Enum;
using MinhasFinancas.Domain.Financas.Commands;
using MinhasFinancas.Infra.Interface;
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
        private readonly IUnitOfWork _uow;

        public FinancasAppService(IBusHandler bus, 
                                  IFinancasQueryRepository movimentoFinanceiroQueryRepository, 
                                  IUnitOfWork uow)
        {
            _bus = bus;
            _financasQueryRepository = movimentoFinanceiroQueryRepository;
            _uow = uow;
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

                if (result.IsFailed)
                {
                    _uow.Rollback();
                    return result.ToResult();
                }

                _uow.Commit();
                return result.ToResult<bool>();
            }
            catch (Exception)
            {
                _uow.Rollback();
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
                if (result.IsFailed)
                {
                    _uow.Rollback();
                    return result.ToResult();
                }

                _uow.Commit();
                return result.ToResult<MovimentoFinanceiroViewModel>();
            }
            catch (Exception)
            {
                _uow.Rollback();
                throw;
            }
        }

        public async Task<IAsyncEnumerable<MovimentoFinanceiroViewModel>> GetAllFinancas(Guid usuarioId)
            => await Task.FromResult(_financasQueryRepository.GetAllFinancas(usuarioId));
    }
}
