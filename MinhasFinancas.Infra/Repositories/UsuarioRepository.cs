using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Domain.Interface;
using MinhasFinancas.Infra.Data;

namespace MinhasFinancas.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _context;

        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Usuario entity)
            => _context.Usuarios.AddAsync(entity);

        public void Update(Usuario entity)
            => _context.Update(entity);

        public void Delete(Usuario entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
