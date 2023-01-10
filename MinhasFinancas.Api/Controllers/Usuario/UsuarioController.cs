using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.ViewModel.ViewModels;
using System;
using System.Threading.Tasks;

namespace MinhasFinancas.Api.Controllers.Usuario
{
    [ApiController]
    [Route("api/cliente")]
    [Authorize]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        /// <summary>
        /// Realiza o login do usuário
        /// </summary>
        [HttpGet("acesso")]
        [ProducesResponseType(typeof(UsuarioCredencialViewModel), 200)]
        [ProducesResponseType(typeof(UsuarioCredencialViewModel), 404)]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromRoute] LoginViewModel request)
        {
            var result = await _usuarioAppService.Login(request);
            
            if(result is null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Realiza o cadastro de um novo usuário
        /// </summary>
        [HttpPost("cadastrarUsuario")]
        [ProducesResponseType(typeof(Result<Guid>), 201)]
        [ProducesResponseType(typeof(Result<IError>), 400)]
        [AllowAnonymous]
        public async Task<IActionResult> CadastrarUsuario([FromBody] NewUsuarioViewModel request)
        {
            var result = await _usuarioAppService.CadastrarUsuario(request);
            if (result.IsFailed)
                return BadRequest(result.Errors);

            return Ok(result.Value);
        }

        /// <summary>
        /// Altera o cadastro do usuário
        /// </summary>
        [HttpPatch("alterarUsuario")]
        [ProducesResponseType(typeof(Result<bool>), 200)]
        [ProducesResponseType(typeof(Result<IError>), 400)]
        public async Task<IActionResult> AlterarCadastro(Guid usuarioId, [FromBody] UpdateUsuarioViewModel request)
        {
            var result = await _usuarioAppService.AlterarCadastroUsuario(usuarioId, request);
            if (result.IsFailed)
                return BadRequest(result.Errors);

            return Ok(result.Value);
        }
    }
}
