using MinhasFinancas.Domain.Entidades.Usuarios;
using System.Threading.Tasks;

namespace MinhasFinancas.Domain.Interface.Adapters
{
    public interface IRepositoryAdapter
    {
        Task<Usuario> GetUsuarioByEmail(string email);
        Task<Usuario> GetById(int usuarioId);
    }
}
