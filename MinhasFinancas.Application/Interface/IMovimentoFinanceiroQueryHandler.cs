using MinhasFinancas.Application.QueryStack.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Interface
{
    public interface IMovimentoFinanceiroQueryHandler
    {
        Task<IEnumerable<MovimentoFinanceiroViewModel>> GetAll(DateTime data, int tipo);

        Task<bool> ExcluirMovimento(IEnumerable<Guid> id);

        Task<bool> ExcluirMovimento(DateTime data);
    }
}
