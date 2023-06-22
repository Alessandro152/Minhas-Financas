using AutoMapper;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.Domain.Entidades.Usuarios;
using MinhasFinancas.Domain.Interface.Adapters;
using System.Threading.Tasks;

namespace MinhasFinancas.Infra.Adapter
{
    public class UsuarioRepositoryAdapter : IRepositoryAdapter
    {
        private readonly IUsuarioQueryRepository _usuarioQueryRepository;
        private readonly IMapper _mapper;

        public UsuarioRepositoryAdapter(IUsuarioQueryRepository usuarioQueryRepository, IMapper mapper)
        {
            _usuarioQueryRepository = usuarioQueryRepository;
            _mapper = mapper;
        }

        public async Task<Usuario> GetUsuarioByEmail(string email)
            => _mapper.Map<Usuario>(await _usuarioQueryRepository.GetUsuarioByEmail(email));

        public async Task<Usuario> GetById(int usuarioId)
            => _mapper.Map<Usuario>(await _usuarioQueryRepository.GetById(usuarioId));
    }
}
