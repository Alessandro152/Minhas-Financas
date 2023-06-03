using FluentResults;
using MediatR;
using MinhasFinancas.Domain.Commands.Usuarios;
using MinhasFinancas.Domain.Core.Shared;
using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Domain.Interface;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MinhasFinancas.Domain.Cliente.Handlers
{
    public class UsuarioHandler : IRequestHandler<NewUsuarioCommand, Result<Entidade>>,
                                  IRequestHandler<UpdateUsuarioCommand, Result<bool>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IRepositoryAdapter _repositoryAdapter;

        public UsuarioHandler(IUsuarioRepository usuarioRepository, IRepositoryAdapter repositoryAdapter)
        {
            _usuarioRepository = usuarioRepository;
            _repositoryAdapter = repositoryAdapter;
        }

        public async Task<Result<Entidade>> Handle(NewUsuarioCommand message, CancellationToken cancellationToken)
        {
            if (message is null) return Result.Fail(new Error("A command está nula"));

            var validation = message.IsValid();
            if (!validation.IsValid)
                return Result.Fail(validation.Errors.Select(s => s.ErrorMessage));

            if (await _repositoryAdapter.GetUsuario(message.Email) != null)
                return Result.Fail($"Usuário com e-mail {message.Email} já cadastrado");

            var usuario = new Usuario(message.Nome, message.Email);
            usuario.AddLogin(message.Email, message.Senha);

            _usuarioRepository.Add(usuario);

            return usuario;
        }

        public async Task<Result<bool>> Handle(UpdateUsuarioCommand message, CancellationToken cancellationToken)
        {
            if (message is null) return Result.Fail(new Error("A command está nula"));
            
            var validation = message.IsValid();
            if (!validation.IsValid)
                return Result.Fail(validation.Errors.Select(s => s.ErrorMessage));

            var usuario = await _repositoryAdapter.GetUsuarioById(message.UsuarioId);

            if(usuario is null)
                return Result.Fail($"Usuário com e-mail {message.UsuarioId} não encontrado");

            usuario.Editar(message.Nome, message.Email);

            _usuarioRepository.Update(usuario);

            return true;
        }
    }
}
