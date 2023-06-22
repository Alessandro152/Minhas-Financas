using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.Infra.Data;
using MinhasFinancas.Infra.Extensions;
using MinhasFinancas.ViewModel.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace MinhasFinancas.Infra.Repositories
{
    public class UsuarioQueryRepository : IUsuarioQueryRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UsuarioQueryRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<UsuarioViewModel> GetUsuarioByEmail(string email)
            => _mapper.Map<UsuarioViewModel>(await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == email));

        public async Task<UsuarioViewModel> GetById(int usuarioId)
            => _mapper.Map<UsuarioViewModel>(await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == usuarioId));

        public async Task<UsuarioViewModel> Login(LoginViewModel request)
            => await _context.Login.Where(x => x.Email == request.Email && x.Senha.Decrypt() == request.Password)
                                            .Include(i => i.Usuario)
                                            .Select(consulta => new UsuarioViewModel
                                            {
                                                Id = consulta.Id,
                                                Nome = consulta.Usuario.Nome,
                                                Email = consulta.Email
                                            })
                                            .FirstOrDefaultAsync();
    }
}
