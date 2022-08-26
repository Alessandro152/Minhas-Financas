using FluentResults;
using MediatR;
using MinhasFinancas.Domain.Commands.Usuarios;
using MinhasFinancas.Domain.Core.Shared;
using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Domain.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MinhasFinancas.Domain.Cliente.Handlers
{
    public class UsuarioHandler : IRequestHandler<NewUsuarioCommand, Result<Entidade>>,
                                  IRequestHandler<UpdateUsuarioCommand, Result<Entidade>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IDomainNotification _notification;
        private readonly IRepositoryAdapter _repositoryAdapter;

        public UsuarioHandler(IUsuarioRepository usuarioRepository, IDomainNotification notification, IRepositoryAdapter repositoryAdapter)
        {
            _usuarioRepository = usuarioRepository;
            _notification = notification;
            _repositoryAdapter = repositoryAdapter;
        }

        public async Task<Result<Entidade>> Handle(NewUsuarioCommand message, CancellationToken cancellationToken)
        {
            if (message is null) return default;

            var validation = message.IsValid();

            if (!validation.IsValid)
            {
                foreach (var erro in validation.Errors)
                {
                    _notification.AddMessage(erro.ErrorMessage);
                }

                return Result.Fail(_notification.Message);
            }

            if (await _repositoryAdapter.GetUsuario(message.Email)) Result.Fail($"Usuário já cadastrado");

            var usuario = new Usuario(Guid.NewGuid(), message.Nome, message.Email);
            await _usuarioRepository.CadastrarUsuario(usuario);

            return usuario;
        }

        public async Task<Result<Entidade>> Handle(UpdateUsuarioCommand message, CancellationToken cancellationToken)
        {
            if (message is null) return Result.Fail("Command Nula ");
            var validation = message.IsValid();

            if (!validation.IsValid)
            {
                foreach (var erro in validation.Errors)
                {
                    _notification.AddMessage(erro.ErrorMessage);
                }

                return Result.Fail(_notification.Message);
            }

            if (await _repositoryAdapter.GetUsuario(message.Email)) Result.Fail($"Usuário já cadastrado");

            var usuario = new Usuario(message.UsuarioId, message.Nome, message.Email);
            await _usuarioRepository.AlterarCadastroUsuario(usuario);

            return Result.Ok();
        }
    }
}
