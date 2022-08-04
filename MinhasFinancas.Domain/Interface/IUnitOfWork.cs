namespace MinhasFinancas.Application.Interface
{
    public interface IUnitOfWork
    {
        void Commit();

        void Rollback();
    }
}
