using MinhasFinancas.Domain.Entidades.Financas;
using MinhasFinancas.Domain.Interface;
using MinhasFinancas.Infra.Data;

namespace MinhasFinancas.Infra.Repositories
{
    public class MovimentoFinanceiroRepository : IMovimentoFinanceiroRepository
    {
        private readonly DataContext _context;

        public MovimentoFinanceiroRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(MovimentoFinanceiro entity)
            => _context.MovimentoFinanceiro.AddAsync(entity);

        public void Delete(MovimentoFinanceiro entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(MovimentoFinanceiro entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
