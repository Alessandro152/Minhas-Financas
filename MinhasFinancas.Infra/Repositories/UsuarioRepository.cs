using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Domain.Interface;
using MinhasFinancas.Infra.Data;
using System;
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

        public Task<bool> AlterarCadastroUsuario(Usuario entity)
        {
            try
            {
                _context.Usuarios.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Task.FromResult(true);
        }

        public Task<bool> CadastrarUsuario(Usuario entity)
        {
            try
            {
                _context.Usuarios.AddAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Task.FromResult(true);
        }

        public Task<bool> GravarLogin(Login loginEntity)
        {
            try
            {
                _context.Login.AddAsync(loginEntity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Task.FromResult(true);
        }
    }
}
