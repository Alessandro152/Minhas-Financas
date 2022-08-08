using System.Threading.Tasks;

namespace MinhasFinancas.Domain.Interface
{
    public interface IRepositoryAdapter
    {
        Task<bool> GetUsuario(string email);

        Task<bool> GetLogin(string email, string passWord);
    }
}
