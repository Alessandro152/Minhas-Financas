using MinhasFinancas.Application.Interface;
using MinhasFinancas.Application.QueryStack.ViewModel;
using MinhasFinancas.Domain.Cliente.Commands;
using MinhasFinancas.Domain.Interface;
using System;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.AppServices
{
    public class UsuarioAppServiceHandler : IUsuarioAppServiceHandler
    {
        private readonly IBusHandler _bus;
        private readonly IUsuarioQueryRepository _queryHandler;
        private readonly IApplicationAdapter _applicationAdapter;
        private readonly IDomainNotification _notification;

        public UsuarioAppServiceHandler(IBusHandler bus, 
                                        IUsuarioQueryRepository queryHandler, 
                                        IApplicationAdapter applicationAdapter,
                                        IDomainNotification notification)
        {
            _bus = bus;
            _queryHandler = queryHandler;
            _applicationAdapter = applicationAdapter;
            _notification = notification;
        }

        public async Task<ResultViewModel> AlterarCadastroUsuario(CadastroViewModel dados)
        {
            try
            {
                var command = new UpdateUsuarioCommand(dados.UsuarioId, dados.UsuarioNome, dados.UsuarioEmail, dados.UsuarioSenha);
                var result = await _bus.SendCommand<dynamic, UpdateUsuarioCommand>(command).ConfigureAwait(false);

                return _applicationAdapter.RetornarDomainResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<dynamic> CadastrarUsuario(CadastroViewModel usuario)
        {
            try
            {
                var command = new NewUsuarioCommand(usuario.UsuarioNome, usuario.UsuarioEmail, usuario.UsuarioSenha);
                return await _bus.SendCommand<dynamic, NewUsuarioCommand>(command).ConfigureAwait(false);

                //return _applicationAdapter.RetornarDomainResult(result);
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
