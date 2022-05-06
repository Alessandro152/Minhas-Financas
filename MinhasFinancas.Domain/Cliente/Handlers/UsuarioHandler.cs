using MediatR;
using MinhasFinancas.Domain.Cliente.Commands;
using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Domain.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MinhasFinancas.Domain.Cliente.Handlers
{
    public class UsuarioHandler : IRequestHandler<NewUsuarioCommand, bool>, IRequestHandler<NewLoginCommand, bool>
    {
        private readonly IUsuarioRepository _repo;
        private readonly IBusHandler _busHandler;

        public UsuarioHandler(IUsuarioRepository repo, IBusHandler busHandler)
        {
            _repo = repo;
            _busHandler = busHandler;
        }

        public async Task<bool> Handle(NewUsuarioCommand message, CancellationToken cancellationToken)
        {
            if (message is null) return false;

            try
            {
                var userEntity = new Usuario(message.Nome, message.Email, message.PassWord);
                var result = await _repo.CadastrarUsuario(userEntity).ConfigureAwait(false);

                if (!result) return false; //TODO - Criar domain notification;

                var loginCommand = new NewLoginCommand(message.Email, message.PassWord, userEntity.Id);
                return await _busHandler.SendCommand<bool, NewLoginCommand>(loginCommand).ConfigureAwait(false);
            }
            catch (Exception)
            {
                //TODO - Não lançar exception e sim domain notification
                throw;
            }
        }

        public async Task<bool> Handle(NewLoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var loginEntity = new Login(request.EMail, request.Password, request.ClienteId);
                var result = await _repo.GravarLogin(loginEntity).ConfigureAwait(false);

                if (!result) return false;

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
