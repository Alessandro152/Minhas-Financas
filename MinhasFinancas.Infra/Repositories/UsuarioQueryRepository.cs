using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Infra.Data;
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

        public async Task<Usuario> GetUsuarioById(int usuarioId)
            => await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == usuarioId);

        public async Task<bool> GetLogin(string email, string passWord)
            => await _context.Usuarios.AnyAsync(x => x.Email == email);

        public async Task<UsuarioViewModel> Logar(LoginViewModel request)
        {
            var query = await _context.Login.Where(x => x.Email == request.Email && x.Senha == request.Password)
                                            .Include(i => i.Usuario)
                                            .Select(consulta => new UsuarioViewModel
                                            {
                                                Id = consulta.Id,
                                                Nome = consulta.Usuario.Nome,
                                                Email = consulta.Email
                                            })
                                            .FirstOrDefaultAsync();

            return query;
        }
    }
}
