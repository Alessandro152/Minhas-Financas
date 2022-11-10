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

        public async Task UpdateAsync(Usuario entity)
            => _context.Usuarios.Update(entity);

        public async Task InsertAsync(Usuario entity)
            => await _context.Usuarios.AddAsync(entity);
    }
}
