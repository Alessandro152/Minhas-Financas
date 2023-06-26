using FluentResults;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.Domain.Core.Enums;
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
        private readonly IUnitOfWork _uow;

        public FinancasAppService(IBusHandler bus,
                                  IFinancasQueryRepository movimentoFinanceiroQueryRepository,
                                  IUnitOfWork uow)
        {
            _bus = bus;
            _financasQueryRepository = movimentoFinanceiroQueryRepository;
            _uow = uow;
        }

        public async Task<Result<MovimentoFinanceiroViewModel>> Adicionar(NewMovimentoFinanceiroViewModel request)
        {
            var command = new NewMovimentoFinanceiroCommand(request.Valor,
                                                            request.Descricao,
                                                            request.Data,
                                                            (TipoMovimentoEnum)request.Tipo,
                                                            request.Pago ? SimNaoEnum.Sim : SimNaoEnum.Nao,
                                                            request.Recebido ? SimNaoEnum.Sim : SimNaoEnum.Nao,
                                                            request.UsuarioId);

            var result = await _bus.SendCommand(command);
            if (result.IsFailed)
            {
                _uow.Rollback();
                return result.ToResult();
            }

            _uow.Commit();
            return result.ToResult<MovimentoFinanceiroViewModel>();
        }

        public async Task<Result<bool>> Atualizar(int idMovimentoFinanceiro, UpdateMovimentoFinanceiroViewModel request)
        {
            var command = new UpdateMovimentoFinanceiroCommand(idMovimentoFinanceiro,
                                                               request.Valor,
                                                               request.Descricao,
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

        public async Task<IAsyncEnumerable<MovimentoFinanceiroViewModel>> GetReceitasByData(int idUsuario, DateTime data)
            => await Task.FromResult(_financasQueryRepository.GetReceitasByData(idUsuario, data));

        public async Task<IAsyncEnumerable<MovimentoFinanceiroViewModel>> GetDespesasByData(int idUsuario, DateTime data)
            => await Task.FromResult(_financasQueryRepository.GetDespesasByData(idUsuario, data));

        public async Task<IAsyncEnumerable<MovimentoFinanceiroViewModel>> GetByUsuarioId(int usuarioId)
            => await Task.FromResult(_financasQueryRepository.GetByUsuarioId(usuarioId));
    }
}
