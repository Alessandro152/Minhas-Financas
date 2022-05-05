using MinhasFinancas.Infra.Data;
using MinhasFinancas.Infra.Interface;

namespace MinhasFinancas.Infra.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChangesAsync();
        }

        public void Rollback()
        {
            //GC Act
        }
    }
}
