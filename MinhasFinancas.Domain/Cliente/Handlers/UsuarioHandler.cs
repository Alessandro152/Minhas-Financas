using MediatR;
using MinhasFinancas.Domain.Cliente.Commands;
using MinhasFinancas.Domain.Cliente.Validations;
using MinhasFinancas.Domain.Core.Shared;
using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Domain.Interface;
using MinhasFinancas.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MinhasFinancas.Domain.Cliente.Handlers
{
    public class UsuarioHandler : IRequestHandler<NewUsuarioCommand, Result>, 
                                  IRequestHandler<NewLoginCommand, Result>,
                                  IRequestHandler<UpdateUsuarioCommand, Result>
    {
        private readonly IUsuarioRepository _repo;
        private readonly IBusHandler _busHandler;
        private readonly IDomainNotification _notification;

        private readonly UsuarioValidation _validation;
        private readonly LoginValidation _loginValidation;

        public UsuarioHandler(IUsuarioRepository repo, IBusHandler busHandler, IDomainNotification notification)
        {
            _repo = repo;
            _busHandler = busHandler;
            _notification = notification;
            _validation = new UsuarioValidation();
            _loginValidation = new LoginValidation();
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

                    return new Result { HasError = true, ErrorMessage = _notification.Message };
                }

                // Gerar o value object
                var valueObject = new LoginVO(message.Email, message.PassWord);

                // Gerar a entidade
                var entity = new Usuario(message.Nome, valueObject);

                var result = await _repo.CadastrarUsuario(entity).ConfigureAwait(false);

                if (!result)
                {
                    return new Result { ErrorMessage = new List<string> { $"Falha ao cadastrar o usuário - {entity}" } };
                };

                var loginCommand = new NewLoginCommand(message.Email, message.PassWord, entity.Id);
                var resultCommand = await _busHandler.SendCommand<dynamic, NewLoginCommand>(loginCommand).ConfigureAwait(false);

                if (resultCommand.HasError)
                {
                    return new Result { HasError = resultCommand.HasError, ErrorMessage = resultCommand.ErrorMessage };
                }

            }
            catch (Exception ex)
            {
                return new Result { HasError = true, ErrorMessage = new List<string> { ex.Message } };
            }

            return default;
        }

        public async Task<Result> Handle(NewLoginCommand message, CancellationToken cancellationToken)
        {
            if (message is null) return new Result { HasError = true, ErrorMessage = new List<string> { "Command Nula " } };

            try
            {
                var validationResult = _loginValidation.Validate(message);

                if (!validationResult.IsValid)
                {
                    foreach (var item in validationResult.Errors)
                    {
                        _notification.AddMessage(item.ErrorMessage);
                    }

                    return new Result { HasError = true, ErrorMessage = _notification.Message };
                }

                var entity = new Login(message.EMail, message.Password, message.ClienteId);
                var result = await _repo.GravarLogin(entity).ConfigureAwait(false);

                if (!result)
                {
                    return new Result { ErrorMessage = new List<string> { $"Falha ao cadastrar o usuário - {entity}" } };
                };

                return new Result { HasError = false };
            }
            catch (Exception ex)
            {
                return new Result { HasError = true, ErrorMessage = new List<string> { ex.Message } };
            }
        }

        public async Task<Result> Handle(UpdateUsuarioCommand message, CancellationToken cancellationToken)
        {
            if (message is null) return new Result { HasError = true, ErrorMessage = new List<string> { "Command Nula " } };

            try
            {
                // Gerar o value object
                var valueObject = new LoginVO(message.Email, message.Password);

                // Gerar a entidade
                var entity = new Usuario(message.ClienteId, message.Nome, valueObject);

                var result = await _repo.AlterarCadastroUsuario(entity).ConfigureAwait(false);

                if (!result)
                {
                    return new Result { ErrorMessage = new List<string> { $"Falha ao cadastrar o usuário - {entity}" } };
                };
            }
            catch (Exception ex)
            {
                return new Result { HasError = true, ErrorMessage = new List<string> { ex.Message } };
            }

            return new Result { HasError = false };
        }
    }
}
