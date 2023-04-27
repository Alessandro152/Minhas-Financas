using MinhasFinancas.ViewModel.ViewModels;
using System;
using System.Collections.Generic;

namespace MinhasFinancas.Application.Interface
{
    public interface IFinancasQueryRepository
    {
        IAsyncEnumerable<MovimentoFinanceiroViewModel> GetAll(DateTime data, int tipo);
        IAsyncEnumerable<MovimentoFinanceiroViewModel> GetAllFinancas(Guid usuarioId);
    }
}
