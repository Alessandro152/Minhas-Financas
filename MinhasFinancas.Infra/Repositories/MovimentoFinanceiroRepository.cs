using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Domain.Interface;
using MinhasFinancas.Infra.Data;
using System;
using System.Threading.Tasks;

namespace MinhasFinancas.Infra.Repositories
{
    public class MovimentoFinanceiroRepository : IMovimentoFinanceiroRepository
    {
        private readonly DataContext _context;

        public MovimentoFinanceiroRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> GravarMovimentoFinanceiro(MovimentoFinanceiro entity)
        {
            try
            {
                await _context.Valores.AddAsync(entity).ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
