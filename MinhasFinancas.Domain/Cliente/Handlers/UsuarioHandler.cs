using MediatR;
using MinhasFinancas.Domain.Cliente.Commands;
using MinhasFinancas.Domain.Cliente.Validations;
using MinhasFinancas.Domain.Core.Shared;
using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MinhasFinancas.Domain.Cliente.Handlers
{
    public class UsuarioHandler : IRequestHandler<NewUsuarioCommand, Result>, IRequestHandler<NewLoginCommand, Result>
    {
        private readonly IUsuarioRepository _repo;
        private readonly IBusHandler _busHandler;
        private readonly IDomainNotification _notification;

        private readonly UsuarioValidation _validation;

        public UsuarioHandler(IUsuarioRepository repo, IBusHandler busHandler, IDomainNotification notification)
        {
            _repo = repo;
            _busHandler = busHandler;
            _notification = notification;
            _validation = new UsuarioValidation();
        }

        public async Task<Result> Handle(NewUsuarioCommand message, CancellationToken cancellationToken)
        {
            if (message is null) return new Result { HasError = true, ErrorMessage = new List<string> { "Command Nula " } };

            try
            {
                var validationResult = _validation.Validate(message);

                if (!validationResult.IsValid)
                {
                    foreach (var item in validationResult.Errors)
                    {
                        _notification.AddMessage(item.ErrorMessage);
                    }

                    return new Result { ErrorMessage = _notification.Message };
                }

                var userEntity = new Usuario(message.Nome, message.Email, message.PassWord);
                var result = await _repo.CadastrarUsuario(userEntity).ConfigureAwait(false);

                if (!result)
                {
                    return new Result { ErrorMessage = new List<string> { $"Falha ao cadastrar o usuário - {userEntity}" } };
                };

                var loginCommand = new NewLoginCommand(message.Email, message.PassWord, userEntity.Id);
                var resultCommand = await _busHandler.SendCommand<dynamic, NewLoginCommand>(loginCommand).ConfigureAwait(false);

                return new Result { HasError = false };

            }
            catch (Exception ex)
            {
                return new Result { HasError = true, ErrorMessage = new List<string> { ex.Message } };
            }
        }

        public async Task<Result> Handle(NewLoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var loginEntity = new Login(request.EMail, request.Password, request.ClienteId);
                var result = await _repo.GravarLogin(loginEntity).ConfigureAwait(false);

                //if (!result) return false;

                return new Result { HasError = false };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
