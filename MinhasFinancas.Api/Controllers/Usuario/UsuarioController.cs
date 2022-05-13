using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.Application.QueryStack.ViewModel;
using MinhasFinancas.Infra.Interface;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Api.Controllers.Usuario
{
    [ApiController]
    [Route("cliente")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppServiceHandler _usuarioAppService;
        private readonly IUnitOfWork _uow;
        private readonly ITokenService _tokenService;

        public UsuarioController(IUsuarioAppServiceHandler usuarioAppService, IUnitOfWork uow, ITokenService tokenService)
        {
            _usuarioAppService = usuarioAppService;
            _uow = uow;
            _tokenService = tokenService;
        }

        [HttpGet]
        [Route("acesso")]
        public async Task<ActionResult<dynamic>> Login([FromQuery] LoginViewModel dados)
        {
            var user = await _usuarioAppService.Login(dados).ConfigureAwait(false);

            if (user is null)
            {
                return NotFound();
            }

            var token = _tokenService.GenerateToken(user);

            return new
            {
                user,
                token
            };
        }

        [HttpPost]
        [Route("cadastro")]
        public async Task<ActionResult<bool>> CadastrarUsuario([FromBody] UsuarioViewModel dados)
        {
            var result = await _usuarioAppService.CadastrarUsuario(dados).ConfigureAwait(false);

            if (!result.HasError)
            {
                _uow.Rollback();

                var message = new StringBuilder();

                foreach (var item in result.ErrorMessage)
                {
                    message.Append(item);
                }

                return BadRequest($"Falha ao cadastrar o usuário. - {message}");
            }

            _uow.Commit();
            return Ok(result);
        }

        [HttpPut]
        [Authorize]
        public bool AlterarCadastro([FromBody] UsuarioViewModel dados)
        {
            return true;
        }

        [HttpDelete]
        [Authorize]
        public bool ExcluirCadastroUsuario(int Id)
        {
            return true;
        }
    }
}
