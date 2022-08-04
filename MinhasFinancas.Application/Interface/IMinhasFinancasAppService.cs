using FluentResults;
using MinhasFinancas.Application.QueryStack.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Interface
{
    public interface IMinhasFinancasAppService
    {
        Task<Result> GravarMovimentoFinanceiro(MovimentoFinanceiroViewModel dados);

        Task<Result> AtualizarMovimentoFinanceiro(MovimentoFinanceiroViewModel dados);

        Task<IEnumerable<MovimentoFinanceiroViewModel>> AllReceitas(DateTime data);

        Task<IEnumerable<MovimentoFinanceiroViewModel>> AllDespesas(DateTime data);

        Task<bool> ExcluirMovimentoFinanceiro(IEnumerable<Guid> id);

        Task<bool> ExcluirMovimentoFinanceiro(DateTime id);
    }
}
