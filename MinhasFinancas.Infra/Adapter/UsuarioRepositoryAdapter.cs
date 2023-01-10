﻿using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Domain.Interface;
using MinhasFinancas.Infra.Interface;
using System.Threading.Tasks;

namespace MinhasFinancas.Infra.Adapter
{
    public class UsuarioRepositoryAdapter : IRepositoryAdapter
    {
        private readonly IUsuarioQueryRepository _usuarioQueryRepository;

        public UsuarioRepositoryAdapter(IUsuarioQueryRepository usuarioQueryRepository)
        {
            _usuarioQueryRepository = usuarioQueryRepository;
        }

        public async Task<bool> GetLogin(string email, string passWord)
            => await _usuarioQueryRepository.GetLogin(email, passWord);

        public async Task<Usuario> GetUsuario(string email)
            => await _usuarioQueryRepository.GetUsuario(email);
    }
}
