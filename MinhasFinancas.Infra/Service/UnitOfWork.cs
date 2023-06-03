using MinhasFinancas.Application.Interface;
using MinhasFinancas.Infra.Data;
using System;

namespace MinhasFinancas.Infra.Service
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public UnitOfWork(DataContext context)
        {
            Context = context;
        }

        public DataContext Context { get; }

        public void Commit()
            => Context.SaveChangesAsync();

        public void Rollback()
            => Dispose();

        public void Dispose()
            => GC.SuppressFinalize(this);
    }
}
