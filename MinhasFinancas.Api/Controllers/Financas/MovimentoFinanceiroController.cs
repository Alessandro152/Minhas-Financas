using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.Infra.Interface;
using MinhasFinancas.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhasFinancas.Api.Controllers.Financas
{
    [Controller]
    [Route("api/financas")]
    [Produces("application/json")]
    public class MovimentoFinanceiroController : ControllerBase
    {
        private readonly IFinancasAppService _appServiceHandler;

        public MovimentoFinanceiroController(IFinancasAppService appServiceHandler)
        {
            _appServiceHandler = appServiceHandler;
        }

        [HttpGet]
        [Route("allReceitas")]
        [ProducesResponseType(typeof(IEnumerable<MovimentoFinanceiroViewModel>), 200)]
        [ProducesResponseType(typeof(MovimentoFinanceiroViewModel), 404)]
        [Authorize]
        public async Task<ActionResult<MovimentoFinanceiroViewModel>> AllReceitas([FromQuery] DateTime data)
        {
            var result = await _appServiceHandler.GetAllReceitas(data.Date);

            if (result is null)
                return NotFound(new { Message = $"Receitas em {data} não encontrado." });

            return Ok(result);
        }

        [HttpGet]
        [Route("allDespesas")]
        [ProducesResponseType(typeof(IEnumerable<MovimentoFinanceiroViewModel>), 200)]
        [ProducesResponseType(typeof(MovimentoFinanceiroViewModel), 404)]
        [Authorize]
        public async Task<ActionResult<UpdateMovimentoFinanceiroViewModel>> AllDespesas([FromQuery] DateTime data)
        {
            var result = await _appServiceHandler.GetAllDespesas(data.Date);

            if (result is null)
                return NotFound(new { Message = $"Despesas em {data} não encontrado." });

            return Ok(result);
        }

        [HttpPost]
        [Route("salvarMovimento")]
        [ProducesResponseType(typeof(NewMovimentoFinanceiroViewModel), 201)]
        [ProducesResponseType(typeof(Result<IError>), 400)]
        [Authorize]
        public async Task<ActionResult<bool>> GravarMovimentoFinanceiro([FromBody] NewMovimentoFinanceiroViewModel request)
        {
            var result = await _appServiceHandler.GravarMovimentoFinanceiro(request);

            if (result.IsFailed)
                return BadRequest(result.Errors);

            return Created("", result);
        }

        [HttpPut]
        [Route("{idMovimentoFinanceiro}/atualizarMovimento")]
        [ProducesResponseType(typeof(UpdateMovimentoFinanceiroViewModel), 200)]
        [ProducesResponseType(typeof(Result<IError>), 400)]
        [Authorize]
        public async Task<ActionResult<bool>> AtualizarMovimentoFinanceiro(Guid idMovimentoFinanceiro, [FromBody] UpdateMovimentoFinanceiroViewModel dados)
        {
            var result = await _appServiceHandler.AtualizarMovimentoFinanceiro(idMovimentoFinanceiro, dados);

            if (result.IsFailed)
                return BadRequest(result.Errors);

            return Ok(result);
        }
    }
}
