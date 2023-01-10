﻿using FluentResults;
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
                return Result.Fail<Entidade>(validation.Errors.Select(s => s.ErrorMessage));

            if (await _repositoryAdapter.GetUsuario(message.Email) != null)
                Result.Fail($"Usuário com e-mail {message.Email} já cadastrado");

            var login = new Login(Guid.NewGuid(), message.Email, message.Senha);
            var usuario = new Usuario(Guid.NewGuid(), message.Nome, message.Email);

            await _usuarioRepository.InsertAsync(usuario);
            await _usuarioRepository.InsertAsync(login);

            return usuario;
        }

        public async Task<Result<bool>> Handle(UpdateUsuarioCommand message, CancellationToken cancellationToken)
        {
            if (message is null) return Result.Fail(new Error("A command está nula"));
            
            var validation = message.IsValid();
            if (!validation.IsValid)
                return Result.Fail(validation.Errors.Select(s => s.ErrorMessage));

            await _usuarioRepository.UpdateAsync(new Usuario(message.UsuarioId, 
                                                             message.Nome, 
                                                             message.Email));
            return true;
        }
    }
}
