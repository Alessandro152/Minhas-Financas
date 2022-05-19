using MinhasFinancas.Application.Interface;
using MinhasFinancas.Application.QueryStack.ViewModel;
using MinhasFinancas.Infra.Data;
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

        public Task<UsuarioViewModel> Logar(LoginViewModel login)
        {
            if (login is null) return default;

            try
            {
                var result = _context.Login.Where(x => x.EMail == login.Email && x.PassWord == login.PassWord).FirstOrDefault();

                if (result != null)
                {
                    var user = _context.Usuarios.Where(x => x.Id == result.ClienteId).FirstOrDefault();

                    return Task.FromResult(new UsuarioViewModel
                    {
                        Id = user.Id,
                        Nome = user.Nome,
                        Email = user.LoginVO.Email
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return default;
        }
    }
}
