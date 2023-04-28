using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhasFinancas.Api.Controllers.Financas
{
    [Controller]
    [Route("api/financas")]
    [Produces("application/json")]
    [Authorize]
    public class MovimentoFinanceiroController : ControllerBase
    {
        private readonly IFinancasAppService _appServiceHandler;

        public MovimentoFinanceiroController(IFinancasAppService appServiceHandler)
        {
            _appServiceHandler = appServiceHandler;
        }

        [HttpGet]
        [Route("receitas")]
        [ProducesResponseType(typeof(IEnumerable<MovimentoFinanceiroViewModel>), 200)]
        [ProducesResponseType(typeof(IEnumerable<MovimentoFinanceiroViewModel>), 404)]
        public async Task<IActionResult> AllReceitas([FromQuery] DateTime data)
        {
            var result = await _appServiceHandler.GetAllReceitas(data.Date);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("despesas")]
        [ProducesResponseType(typeof(IEnumerable<MovimentoFinanceiroViewModel>), 200)]
        [ProducesResponseType(typeof(IEnumerable<MovimentoFinanceiroViewModel>), 404)]
        public async Task<IActionResult> AllDespesas([FromQuery] DateTime data)
        {
            var result = await _appServiceHandler.GetAllDespesas(data.Date);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Route("salvarMovimento")]
        [ProducesResponseType(typeof(NewMovimentoFinanceiroViewModel), 201)]
        [ProducesResponseType(typeof(Result<IReason>), 400)]
        public async Task<IActionResult> GravarMovimentoFinanceiro([FromBody] NewMovimentoFinanceiroViewModel request)
        {
            var result = await _appServiceHandler.GravarMovimentoFinanceiro(request);

            if (result.IsFailed)
                return BadRequest(result.Reasons);

            return Created("", result.Value);
        }

        [HttpPut]
        [Route("{idMovimentoFinanceiro}/atualizarMovimento")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(Result<IReason>), 400)]
        public async Task<IActionResult> AtualizarMovimentoFinanceiro(Guid idMovimentoFinanceiro, [FromBody] UpdateMovimentoFinanceiroViewModel dados)
        {
            var result = await _appServiceHandler.AtualizarMovimentoFinanceiro(idMovimentoFinanceiro, dados);

            if (result.IsFailed)
                return BadRequest(result.Reasons);

            return Ok(result.Value);
        }
    }
}
