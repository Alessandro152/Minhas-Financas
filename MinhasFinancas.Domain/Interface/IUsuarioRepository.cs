using MinhasFinancas.Domain.Entidades;
using System.Threading.Tasks;

namespace MinhasFinancas.Domain.Interface
{
    public interface IUsuarioRepository
    {
        Task InsertAsync(Usuario dados);

        Task UpdateAsync(Usuario entity);
    }
}
