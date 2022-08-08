using FluentResults;
using MediatR;
using MinhasFinancas.Domain.Cliente.Commands;
using MinhasFinancas.Domain.Core.ValueObjects;
using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Domain.Interface;
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
        private readonly IRepositoryAdapter _repositoryAdapter;

        public UsuarioHandler(IUsuarioRepository usuarioRepository, IDomainNotification notification, IRepositoryAdapter repositoryAdapter)
        {
            _usuarioRepository = usuarioRepository;
            _notification = notification;
            _repositoryAdapter = repositoryAdapter;
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

                //Verificar se o usuário já está cadastrado
                if (await _repositoryAdapter.GetUsuario(message.Email))
                {
                    Result.Fail($"Usuário já cadastrado");
                }

                //Verificar se as credenciais de login já existem
                if (await _repositoryAdapter.GetLogin(message.Email, message.PassWord))
                {
                    Result.Fail($"Credenciais de acesso {message.Email} {message.PassWord} já existem");
                }

                //Gerar ValueObject
                var loginVO = new LoginVO(message.Email, message.PassWord);
                var enderecoVO = new EnderecoVO(message.Cidade, message.UF);

                // Gerar a entidade
                var usuario = new Usuario(Guid.NewGuid(), message.Nome, enderecoVO, loginVO);
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
                var loginVO = new LoginVO(message.Email, message.Password);
                var enderecoVO = new EnderecoVO(message.Cidade, message.UF);

                // Gerar a entidade
                var usuario = new Usuario(message.ClienteId, message.Nome, enderecoVO, loginVO);
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
