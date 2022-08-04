using FluentResults;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.Application.QueryStack.ViewModel;
using MinhasFinancas.Domain.Cliente.Commands;
using System;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.AppServices
{
    public class UsuarioAppServiceHandler : IUsuarioAppService
    {
        private readonly IBusHandler _bus;
        private readonly IUsuarioQueryRepository _queryHandler;

        public UsuarioAppServiceHandler(IBusHandler bus, 
                                        IUsuarioQueryRepository queryHandler)
        {
            _bus = bus;
            _queryHandler = queryHandler;
        }

        public async Task AlterarCadastroUsuario(CadastroViewModel dados)
        {
            try
            {
                var command = new UpdateUsuarioCommand(dados.UsuarioId, dados.UsuarioNome, dados.UsuarioEmail, dados.UsuarioSenha);
                _bus.SendCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result> CadastrarUsuario(CadastroViewModel usuario)
        {
            try
            {
                var command = new NewUsuarioCommand(usuario.UsuarioNome, usuario.UsuarioEmail, usuario.UsuarioSenha);
                return await _bus.SendCommand<Result, NewUsuarioCommand>(command).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UsuarioViewModel> Login(LoginViewModel dados)
        {
            try
            {
                return await _queryHandler.Logar(dados).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
