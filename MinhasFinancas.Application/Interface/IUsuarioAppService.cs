using FluentResults;
using MinhasFinancas.ViewModel.ViewModels;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Interface
{
    public interface IUsuarioAppService
    {
        Task<Result<UsuarioViewModel>> Adicionar(NewUsuarioViewModel usuario);
        Task<Result<bool>> Atualizar(int id, UpdateUsuarioViewModel dados);
        Task<UsuarioViewModel> GetById(int idUsuario);
    }
}
