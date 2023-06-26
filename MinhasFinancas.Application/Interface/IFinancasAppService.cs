using FluentResults;
using MinhasFinancas.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Interface
{
    public interface IFinancasAppService
    {
        Task<Result<MovimentoFinanceiroViewModel>> Adicionar(NewMovimentoFinanceiroViewModel dados);
        Task<Result<bool>> Atualizar(int idMovimentoFinanceiro, UpdateMovimentoFinanceiroViewModel dados);
        Task<IAsyncEnumerable<MovimentoFinanceiroViewModel>> GetReceitasByData(int idUsuario, DateTime data);
        Task<IAsyncEnumerable<MovimentoFinanceiroViewModel>> GetDespesasByData(int idUsuario, DateTime data);
        Task<IAsyncEnumerable<MovimentoFinanceiroViewModel>> GetByUsuarioId(int usuarioId);
    }
}
