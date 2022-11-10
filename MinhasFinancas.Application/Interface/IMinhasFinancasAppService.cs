using FluentResults;
using MinhasFinancas.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Interface
{
    public interface IMinhasFinancasAppService
    {
        Task<Result<MovimentoFinanceiroViewModel>> GravarMovimentoFinanceiro(NewMovimentoFinanceiroViewModel dados);

        Task<Result<bool>> AtualizarMovimentoFinanceiro(UpdateMovimentoFinanceiroViewModel dados);

        Task<IEnumerable<MovimentoFinanceiroViewModel>> AllReceitas(DateTime data);

        Task<IEnumerable<MovimentoFinanceiroViewModel>> AllDespesas(DateTime data);

        Task<bool> ExcluirMovimentoFinanceiro(IEnumerable<Guid> id);

        Task<bool> ExcluirMovimentoFinanceiro(DateTime id);
    }
}
