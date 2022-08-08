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

        public async Task<Result> AlterarCadastroUsuario(CadastroViewModel dados)
        {
            try
            {
                var command = new UpdateUsuarioCommand(dados.Id, dados.Nome, dados.Email, dados.Senha);
                return await _bus.SendCommand<Result, UpdateUsuarioCommand>(command);
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
                var command = new NewUsuarioCommand(usuario.Nome, usuario.Cidade, usuario.UF, usuario.Email, usuario.Senha);
                return await _bus.SendCommand<Result, NewUsuarioCommand>(command);
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
