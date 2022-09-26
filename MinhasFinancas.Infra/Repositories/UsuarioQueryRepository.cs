using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> GetLogin(string email, string passWord)
            => await _context.Usuarios.AnyAsync(x => x.Email == email);

        public async Task<UsuarioViewModel> Logar(LoginViewModel login)
        {
            if (login is null) return default;

            var result = await _context.Login.Where(x => x.EMail == login.Email && x.PassWord == login.PassWord).FirstOrDefaultAsync();

            if (result != null)
            {
                var user = await _context.Usuarios.Where(x => x.Id == result.ClienteId).FirstOrDefaultAsync();

                return new UsuarioViewModel
                {
                    Id = user.Id,
                    Nome = user.Nome,
                    Email = user.Email
                };
            }

            return default;
        }
    }
}
