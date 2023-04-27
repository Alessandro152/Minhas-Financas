using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Infra.Data;
using MinhasFinancas.Infra.Interface;
using MinhasFinancas.ViewModel.ViewModels;
using System;
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

        public async Task<Usuario> GetUsuarioById(Guid usuarioId)
            => await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == usuarioId);

        public async Task<bool> GetLogin(string email, string passWord)
            => await _context.Usuarios.AnyAsync(x => x.Email == email);

        public async Task<UsuarioViewModel> Logar(LoginViewModel request)
            => await _context.Login.Where(x => x.Email == request.Email && x.Password == request.Password)
                                   .Include(x => x.Usuario)
                                   .Select(s => new UsuarioViewModel
                                   {
                                       Id = s.Id,
                                       Nome = s.Usuario.Nome,
                                       Email = s.Usuario.Email
                                   })
                                   .FirstOrDefaultAsync();
    }
}
