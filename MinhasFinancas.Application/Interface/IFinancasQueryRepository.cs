using MinhasFinancas.ViewModel.ViewModels;
using System;
using System.Collections.Generic;

namespace MinhasFinancas.Application.Interface
{
    public interface IFinancasQueryRepository
    {
        IAsyncEnumerable<MovimentoFinanceiroViewModel> GetByUsuarioId(int usuarioId);
        IAsyncEnumerable<MovimentoFinanceiroViewModel> GetReceitasByData(int idUsuario, DateTime data);
        IAsyncEnumerable<MovimentoFinanceiroViewModel> GetDespesasByData(int idUsuario, DateTime data);
    }
}
