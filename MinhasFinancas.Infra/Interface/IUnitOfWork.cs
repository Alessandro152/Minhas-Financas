namespace MinhasFinancas.Infra.Interface
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
