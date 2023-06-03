using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.ViewModel.ViewModels;
using System.Threading.Tasks;

namespace MinhasFinancas.Api.Controllers.Logins
{
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public LoginController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        /// <summary>
        /// Realiza o login do usuário
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(UsuarioCredencialViewModel), 200)]
        [ProducesResponseType(typeof(UsuarioCredencialViewModel), 404)]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel request)
        {
            var result = await _usuarioAppService.Login(request);

            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}
