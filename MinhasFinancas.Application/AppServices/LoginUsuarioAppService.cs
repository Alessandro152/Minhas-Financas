using MinhasFinancas.Application.Interface;
using MinhasFinancas.ViewModel.ViewModels;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.AppServices
{
    public class LoginUsuarioAppService : ILoginAppService
    {
        private readonly IUsuarioQueryRepository _usuarioQueryRepository;
        private readonly ITokenAppService _tokenService;

        public LoginUsuarioAppService(IUsuarioQueryRepository usuarioQueryRepository, ITokenAppService tokenAppService)
        {
            _usuarioQueryRepository = usuarioQueryRepository;
            _tokenService = tokenAppService;
        }

        public async Task<UsuarioLoginViewModel> Login(LoginViewModel request)
        {
            var usuario = await _usuarioQueryRepository.Login(request);
            if (usuario is null) return default;

            return new UsuarioLoginViewModel
            {
                Usuario = usuario,
                Token = _tokenService.GenerateToken(usuario)
            };
        }
    }
}
