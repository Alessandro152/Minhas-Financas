using FluentResults;
using MinhasFinancas.Application.QueryStack.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Interface
{
    public interface IMinhasFinancasAppService
    {
        Task<Result> GravarMovimentoFinanceiro(NewMovimentoFinanceiroViewModel dados);

        Task<Result> AtualizarMovimentoFinanceiro(UpdateMovimentoFinanceiroViewModel dados);

        Task<IEnumerable<UpdateMovimentoFinanceiroViewModel>> AllReceitas(DateTime data);

        Task<IEnumerable<UpdateMovimentoFinanceiroViewModel>> AllDespesas(DateTime data);

        Task<bool> ExcluirMovimentoFinanceiro(IEnumerable<Guid> id);

        Task<bool> ExcluirMovimentoFinanceiro(DateTime id);
    }
}
