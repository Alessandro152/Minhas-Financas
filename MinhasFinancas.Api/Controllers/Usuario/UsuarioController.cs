using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhasFinancas.Api.Controllers.Usuario
{
    [ApiController]
    [Route("api/usuarios")]
    [Authorize]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IFinancasAppService _financasAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService, IFinancasAppService financasAppService)
        {
            _usuarioAppService = usuarioAppService;
            _financasAppService = financasAppService;
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
        /// Retornar todos os lançamentos de um usuário
        /// </summary>
        /// <param name="usuarioId">id do usuário</param>
        /// <returns>Uma Lista com todos os lançamentos financeiros do usuário</returns>
        [HttpGet]
        [Route("{usuarioId}/financas")]
        [ProducesResponseType(typeof(IEnumerable<MovimentoFinanceiroViewModel>), 200)]
        [ProducesResponseType(typeof(MovimentoFinanceiroViewModel), 404)]
        public async Task<IActionResult> GetAllFinancas(Guid usuarioId)
            => (IActionResult) await _financasAppService.GetAllFinancas(usuarioId);

        /// <summary>
        /// Realiza o cadastro de um novo usuário
        /// </summary>
        [HttpPost("cadastrarUsuario")]
        [ProducesResponseType(typeof(Result<UsuarioViewModel>), 201)]
        [ProducesResponseType(typeof(Result<IReason>), 400)]
        [AllowAnonymous]
        public async Task<IActionResult> CadastrarUsuario([FromBody] NewUsuarioViewModel request)
        {
            var result = await _usuarioAppService.CadastrarUsuario(request);

            if (result.IsFailed)
                return BadRequest(result.Reasons);

            return Created(string.Empty, result.Value);
        }

        /// <summary>
        /// Altera o cadastro do usuário
        /// </summary>
        [HttpPatch("{usuarioId}/editar")]
        [ProducesResponseType(typeof(Result<bool>), 200)]
        [ProducesResponseType(typeof(Result<IError>), 400)]
        public async Task<IActionResult> AlterarCadastro(Guid usuarioId, [FromBody] UpdateUsuarioViewModel request)
        {
            var result = await _usuarioAppService.AlterarCadastroUsuario(usuarioId, request);

            if (result.IsFailed)
                return BadRequest(result.Reasons);

            return Ok(result.Value);
        }
    }
}
