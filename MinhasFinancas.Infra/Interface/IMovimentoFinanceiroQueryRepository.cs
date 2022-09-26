using MinhasFinancas.Application.QueryStack.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Interface
{
    public interface IMovimentoFinanceiroQueryRepository
    {
        Task<IEnumerable<UpdateMovimentoFinanceiroViewModel>> GetAll(DateTime data, int tipo);

        Task<bool> ExcluirMovimento(IEnumerable<Guid> id);

        Task<bool> ExcluirMovimento(DateTime data);
    }
}
