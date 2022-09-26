using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Domain.Interface;
using MinhasFinancas.Infra.Data;
using System.Threading.Tasks;

namespace MinhasFinancas.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _context;

        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AlterarCadastroUsuario(Usuario entity)
        {
            _context.Usuarios.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> CadastrarUsuario(Usuario entity)
        {
            await _context.Usuarios.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> GravarLogin(Login loginEntity)
        {
            await _context.Login.AddAsync(loginEntity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
