using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.ViewModel.ViewModels;
using System.Threading.Tasks;

namespace MinhasFinancas.Api.Controllers.Logins
{
    [ApiController]
    [Route("api/autenticacao")]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginAppService _loginAppService;

        public LoginController(ILoginAppService loginAppService)
        {
            _loginAppService = loginAppService;
        }

        /// <summary>
        /// Realiza o login de um usuário
        /// </summary>
        /// <param name="request">Body com os parâmetros para autenticação</param>
        /// <returns>Usuário autenticado</returns>
        [HttpPost]
        [ProducesResponseType(typeof(UsuarioLoginViewModel), 200)]
        [ProducesResponseType(typeof(UsuarioLoginViewModel), 404)]
        public async Task<IActionResult> Login([FromBody] LoginViewModel request)
        {
            var result = await _loginAppService.Login(request);

            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}
