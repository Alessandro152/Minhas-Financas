using FluentResults;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.Application.QueryStack.ViewModel;
using MinhasFinancas.Domain.Commands.Usuarios;
using System;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.AppServices
{
    public class UsuarioAppServiceHandler : IUsuarioAppService
    {
        private readonly IBusHandler _bus;
        private readonly IUsuarioQueryRepository _usuarioQueryRepository;
        private readonly ITokenService _tokenService;

        public UsuarioAppServiceHandler(IBusHandler bus,
                                        ITokenService tokenService,
                                        IUsuarioQueryRepository usuarioQueryRepository)
        {
            _bus = bus;
            _tokenService = tokenService;
            _usuarioQueryRepository = usuarioQueryRepository;
        }

        public async Task<Result> AlterarCadastroUsuario(Guid usuarioId, NewCadastroViewModel request)
        {
            try
            {
                var command = new UpdateUsuarioCommand(usuarioId, request.Nome, request.Email);
                return await _bus.SendCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result> CadastrarUsuario(NewCadastroViewModel usuario)
        {
            try
            {
                var command = new NewUsuarioCommand(usuario.Nome, usuario.Email);
                return await _bus.SendCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UsuarioCredencialViewModel> Login(LoginViewModel dados)
        {
            try
            {
                var usuario = await _usuarioQueryRepository.Logar(dados);
                if (usuario is null) return default;

                return new UsuarioCredencialViewModel
                {
                    Usuario = usuario,
                    Token = _tokenService.GenerateToken(usuario)
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
