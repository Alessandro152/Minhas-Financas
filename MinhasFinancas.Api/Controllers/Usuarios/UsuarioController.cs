using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.ViewModel.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhasFinancas.Api.Controllers.Usuarios
{
    [ApiController]
    [Route("api/usuarios")]
    //[Authorize]
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
        /// Retornar todos os lançamentos financeiros de um usuário
        /// </summary>
        /// <param name="idUsuario">Id do usuário</param>
        /// <returns>Uma lista de lançamentos financeiros</returns>
        [HttpGet("{idUsuario}")]
        [ProducesResponseType(typeof(UsuarioViewModel), 200)]
        [ProducesResponseType(typeof(UsuarioViewModel), 404)]
        public async Task<IActionResult> GetById(int idUsuario)
            => Ok(await _usuarioAppService.GetById(idUsuario));

        /// <summary>
        /// Retornar todos os lançamentos financeiros de um usuário
        /// </summary>
        /// <param name="idUsuario">Id do usuário</param>
        /// <returns>Uma lista de lançamentos financeiros</returns>
        [HttpGet("{idUsuario}/financas")]
        [ProducesResponseType(typeof(IEnumerable<MovimentoFinanceiroViewModel>), 200)]
        [ProducesResponseType(typeof(MovimentoFinanceiroViewModel), 404)]
        public async Task<IActionResult> GetFinancasById(int idUsuario)
            => Ok(await _financasAppService.GetById(idUsuario));

        /// <summary>
        /// Realiza o cadastro de um novo usuário
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(Result<UsuarioViewModel>), 201)]
        [ProducesResponseType(typeof(Result<IReason>), 400)]
        [AllowAnonymous]
        public async Task<IActionResult> Cadastrar([FromBody] NewUsuarioViewModel request)
        {
            var result = await _usuarioAppService.Adicionar(request);

            if (result.IsFailed)
                return BadRequest(result.Reasons);

            return Created(string.Empty, result.Value);
        }

        /// <summary>
        /// Altera o cadastro do usuário
        /// </summary>
        [HttpPatch("{usuarioId}")]
        [ProducesResponseType(typeof(Result<bool>), 200)]
        [ProducesResponseType(typeof(Result<IError>), 400)]
        public async Task<IActionResult> AlterarCadastro(int usuarioId, [FromBody] UpdateUsuarioViewModel request)
        {
            var result = await _usuarioAppService.Atualizar(usuarioId, request);

            if (result.IsFailed)
                return BadRequest(result.Reasons);

            return Ok(result.Value);
        }
    }
}
