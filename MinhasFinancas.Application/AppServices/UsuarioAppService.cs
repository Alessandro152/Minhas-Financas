using FluentResults;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.Domain.Commands.Usuarios;
using MinhasFinancas.Infra.Interface;
using MinhasFinancas.ViewModel.ViewModels;
using System;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.AppServices
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IBusHandler _bus;
        private readonly IUsuarioQueryRepository _usuarioQueryRepository;
        private readonly ITokenAppService _tokenService;

        public UsuarioAppService(IBusHandler bus,
                                 ITokenAppService tokenService,
                                 IUsuarioQueryRepository usuarioQueryRepository)
        {
            _bus = bus;
            _tokenService = tokenService;
            _usuarioQueryRepository = usuarioQueryRepository;
        }

        public async Task<Result<bool>> AlterarCadastroUsuario(Guid usuarioId, UpdateUsuarioViewModel request)
        {
            try
            {
                var command = new UpdateUsuarioCommand(usuarioId, request.Nome, request.Email);
                var result = await _bus.SendCommand<UpdateUsuarioCommand, Result<bool>>(command);
                if (result.IsSuccess)
                {
                    //TODO - gerenciar com unit of work commitar ou rollback
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result> CadastrarUsuario(NewUsuarioViewModel usuario)
        {
            try
            {
                var command = new NewUsuarioCommand(usuario.Nome, usuario.Email);
                var x = await _bus.SendCommand(command);

                //TODO - Tratar o controle de transacao aqui
                return x.ToResult();
            }
            catch (Exception ex)
            {
                //TODO - Jogar o rollback aqui
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
