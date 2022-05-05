using MinhasFinancas.Domain.Entidades;
using System.Threading.Tasks;

namespace MinhasFinancas.Domain.Interface
{
    public interface IMovimentoFinanceiroRepository
    {
        Task<bool> GravarMovimentoFinanceiro(MovimentoFinanceiro entity);
    }
}
