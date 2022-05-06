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

        public UsuarioAppServiceHandler(IBusHandler bus, IUsuarioQueryRepository queryHandler)
        {
            _bus = bus;
            _queryHandler = queryHandler;
        }

        public async Task<bool> CadastrarUsuario(UsuarioViewModel usuario)
        {
            try
            {
                var command = new NewUsuarioCommand(usuario.Nome, usuario.Email, usuario.PassWord);
                return await _bus.SendCommand<bool, NewUsuarioCommand>(command).ConfigureAwait(false);
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
