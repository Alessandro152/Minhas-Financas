using MinhasFinancas.Application.Interface;
using MinhasFinancas.Application.QueryStack.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhasFinancas.Infra.Repositories
{
    public class MovimentoFinanceiroQueryRepository : IMovimentoFinanceiroQueryHandler
    {
        public MovimentoFinanceiroQueryRepository()
        {

        }

        public Task<bool> ExcluirMovimento(IEnumerable<Guid> id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExcluirMovimento(DateTime data)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MovimentoFinanceiroViewModel>> GetAll(DateTime data, int tipo)
        {
            throw new NotImplementedException();
        }
    }
}
