using MinhasFinancas.Domain.Entidades;
using System.Threading.Tasks;

namespace MinhasFinancas.Domain.Interface
{
    public interface IUsuarioRepository
    {
        Task<bool> CadastrarUsuario(Usuario dados);

        Task<bool> GravarLogin(Login loginEntity);

        Task<bool> AlterarCadastroUsuario(Usuario entity);
    }
}
