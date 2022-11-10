using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Infra.Data;
using MinhasFinancas.Infra.Interface;
using MinhasFinancas.ViewModel.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasFinancas.Infra.Repositories
{
    public class UsuarioQueryRepository : IUsuarioQueryRepository
    {
        private readonly DataContext _context;

        public UsuarioQueryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetUsuario(string email)
            => await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == email);

        public async Task<bool> GetLogin(string email, string passWord)
            => await _context.Usuarios.AnyAsync(x => x.Email == email);

        public async Task<UsuarioViewModel> Logar(LoginViewModel request)
        {
            if (request is null) return default;
            var result = await _context.Login.Where(x => x.Email == request.Email && x.Password == request.Password)
                                             .Include(x => x.Usuario)
                                             .FirstOrDefaultAsync();
            if (result != null)
            {
                return new UsuarioViewModel
                {
                    Id = result.Usuario.Id,
                    Nome = result.Usuario.Nome,
                    Email = result.Usuario.Email
                };
            }

            return default;
        }
    }
}
