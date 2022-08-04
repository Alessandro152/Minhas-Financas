using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.Application.QueryStack.ViewModel;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Api.Controllers.Usuario
{
    [ApiController]
    [Route("cliente")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly ITokenService _tokenService;

        public UsuarioController(IUsuarioAppService usuarioAppService, ITokenService tokenService)
        {
            _usuarioAppService = usuarioAppService;
            _tokenService = tokenService;
        }

        [HttpGet("acesso")]
        public async Task<ActionResult<dynamic>> Login([FromQuery] LoginViewModel dados)
        {
            var user = await _usuarioAppService.Login(dados).ConfigureAwait(false);

            if (user is null)
            {
                return NotFound();
            }

            var token = _tokenService.GenerateToken(user);

            return Ok(new
            {
                user,
                token
            });
        }

        [HttpPost("cadastrarUsuario")]
        public async Task<ActionResult<dynamic>> CadastrarUsuario([FromBody] CadastroViewModel dados)
        {
            var result = await _usuarioAppService.CadastrarUsuario(dados);

            if (result.IsFailed)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }

        [HttpPut("alterarUsuario")]
        [Authorize]
        public async Task<ActionResult<dynamic>> AlterarCadastro([FromBody] CadastroViewModel dados)
        {
            var result = await _usuarioAppService.AlterarCadastroUsuario(dados).ConfigureAwait(false);

            if (result.IsFailed)
            {
                return BadRequest($"Falha ao alterar o usuário. - {result.Errors}");
            }

            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public bool ExcluirCadastroUsuario(int Id)
        {
            return true;
        }
    }
}
