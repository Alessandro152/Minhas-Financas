using FluentResults;
using MinhasFinancas.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Interface
{
    public interface IFinancasAppService
    {
        Task<Result<MovimentoFinanceiroViewModel>> GravarMovimentoFinanceiro(NewMovimentoFinanceiroViewModel dados);
        Task<Result<bool>> AtualizarMovimentoFinanceiro(Guid idMovimentoFinanceiro, UpdateMovimentoFinanceiroViewModel dados);
        Task<IAsyncEnumerable<MovimentoFinanceiroViewModel>> GetAllReceitas(DateTime data);
        Task<IAsyncEnumerable<MovimentoFinanceiroViewModel>> GetAllDespesas(DateTime data);
        Task<IAsyncEnumerable<MovimentoFinanceiroViewModel>> GetAllFinancas(Guid usuarioId);
    }
}
