using MinhasFinancas.Application.QueryStack.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Interface
{
    public interface IMinhasFinancasAppServiceHandler
    {
        Task<IEnumerable<MovimentoFinanceiroViewModel>> AllReceitas(DateTime data);

        Task<bool> GravarMovimentoFinanceiro(MovimentoFinanceiroViewModel dados);

        Task<IEnumerable<MovimentoFinanceiroViewModel>> AllDespesas(DateTime data);

        Task<bool> AtualizarMovimentoFinanceiro(MovimentoFinanceiroViewModel dados);

        Task<bool> ExcluirMovimentoFinanceiro(IEnumerable<Guid> id);

        Task<bool> ExcluirMovimentoFinanceiro(DateTime id);
    }
}
