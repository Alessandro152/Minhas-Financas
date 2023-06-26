using AutoMapper;
using FluentResults;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.Domain.Commands.Usuarios;
using MinhasFinancas.Domain.Core.Shared;
using MinhasFinancas.ViewModel.ViewModels;
using System;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.AppServices
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IBusHandler _bus;
        private readonly IUsuarioQueryRepository _usuarioQueryRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UsuarioAppService(IBusHandler bus,
                                 IUsuarioQueryRepository usuarioQueryRepository,
                                 IUnitOfWork uow,
                                 IMapper mapper)
        {
            _bus = bus;
            _usuarioQueryRepository = usuarioQueryRepository;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Result<bool>> Atualizar(int usuarioId, UpdateUsuarioViewModel request)
        {
            try
            {
                var command = new UpdateUsuarioCommand(usuarioId, request.Nome, request.Email);
                var result = await _bus.SendCommand<UpdateUsuarioCommand, Result<bool>>(command);

                if (result.IsFailed)
                {
                    _uow.Rollback();
                    return result.ToResult();
                }

                _uow.Commit();
                return result.ToResult<bool>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<UsuarioViewModel>> Adicionar(NewUsuarioViewModel usuario)
        {
            var command = new NewUsuarioCommand(usuario.Nome, usuario.Email, usuario.Senha);
            var result = await _bus.SendCommand(command);

            if (result.IsFailed)
            {
                _uow.Rollback();
                return result.ToResult();
            }

            _uow.Commit();
            return _mapper.Map<Entidade, UsuarioViewModel>(result.Value);
        }

        public async Task<UsuarioViewModel> GetById(int idUsuario)
            => await _usuarioQueryRepository.GetById(idUsuario);
    }
}
