using MinhasFinancas.Domain.Entidades;
using System.Threading.Tasks;

namespace MinhasFinancas.Domain.Interface
{
    public interface IRepositoryAdapter
    {
        Task<Usuario> GetUsuario(string email);

        Task<bool> GetLogin(string email, string passWord);
    }
}
