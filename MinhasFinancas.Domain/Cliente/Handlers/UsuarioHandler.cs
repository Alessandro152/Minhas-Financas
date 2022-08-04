using FluentResults;
using MediatR;
using MinhasFinancas.Domain.Cliente.Commands;
using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Domain.Interface;
using MinhasFinancas.Domain.ValueObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MinhasFinancas.Domain.Cliente.Handlers
{
    public class UsuarioHandler : IRequestHandler<NewUsuarioCommand, Result>, 
                                  IRequestHandler<UpdateUsuarioCommand, Result>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IDomainNotification _notification;

        public UsuarioHandler(IUsuarioRepository usuarioRepository, IDomainNotification notification)
        {
            _usuarioRepository = usuarioRepository;
            _notification = notification;
        }

        public async Task<Result> Handle(NewUsuarioCommand message, CancellationToken cancellationToken)
        {
            if (message is null) return Result.Fail("Command Nula");

            try
            {
                var validationResult = message.IsValid();

                if (!validationResult.IsValid)
                {
                    foreach (var item in validationResult.Errors)
                    {
                        _notification.AddMessage(item.ErrorMessage);
                    }

                    return Result.Fail(_notification.Message);
                }

                //Gerar ValueObject
                var valueObject = new LoginVO(message.Email, message.PassWord);

                // Gerar a entidade
                var usuario = new Usuario(Guid.NewGuid(), message.Nome, valueObject);
                await _usuarioRepository.CadastrarUsuario(usuario);

                var login = new Login(message.Email, message.PassWord, usuario.Id);
                await _usuarioRepository.CadastrarUsuario(usuario);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail($"Falha ao gravar o usuário. {ex.Message}");
            }
        }

        public async Task<Result> Handle(UpdateUsuarioCommand message, CancellationToken cancellationToken)
        {
            if (message is null) return Result.Fail("Command Nula ");

            try
            {
                // Gerar o value object
                var valueObject = new LoginVO(message.Email, message.Password);

                // Gerar a entidade
                var usuario = new Usuario(message.ClienteId, message.Nome, valueObject);
                var result = await _usuarioRepository.AlterarCadastroUsuario(usuario);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail($"Falha ao gravar o usuário. {ex.Message}");
            }
        }
    }
}
