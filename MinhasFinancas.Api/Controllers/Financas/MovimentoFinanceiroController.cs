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
        private readonly IMinhasFinancasAppService _appServiceHandler;
        private readonly IUnitOfWork _uow;

        public MovimentoFinanceiroController(IMinhasFinancasAppService appServiceHandler, IUnitOfWork uow)
        {
            _appServiceHandler = appServiceHandler;
            _uow = uow;
        }

        [HttpGet]
        [Route("allReceitas")]
        [Authorize]
        public async Task<ActionResult<UpdateMovimentoFinanceiroViewModel>> AllReceitas([FromQuery] DateTime data)
        {
            var result = await _appServiceHandler.GetAllReceitas(data.Date);

            if (result is null)
                return NotFound(new { Message = $"Receitas em {data} não encontrado." });

            return Ok(result);
        }

        [HttpGet]
        [Route("allDespesas")]
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
        [Authorize]
        public async Task<ActionResult<bool>> GravarMovimentoFinanceiro([FromBody] NewMovimentoFinanceiroViewModel dados)
        {
            var result = await _appServiceHandler.GravarMovimentoFinanceiro(dados);

            if (result.IsFailed)
            {
                _uow.Rollback();
                return BadRequest(new { Message = $"Falha ao gravar o movimento." });
            }

            _uow.Commit();
            return Ok();
        }

        [HttpPut]
        [Route("atualizarMovimento")]
        [Authorize]
        public async Task<ActionResult<bool>> AtualizarMovimentoFinanceiro([FromBody] UpdateMovimentoFinanceiroViewModel dados)
        {
            var result = await _appServiceHandler.AtualizarMovimentoFinanceiro(dados);

            if (result.IsFailed)
            {
                _uow.Rollback();
                return BadRequest(new { Message = $"Falha ao atualizar o movimento." });
            }

            _uow.Commit();
            return Ok();
        }

        [HttpDelete]
        [Route("excluirMovimento/id")]
        [Authorize]
        public async Task<ActionResult<bool>> ExcluirMovimentoFinanceiro([FromQuery] IEnumerable<Guid> id)
        {
            var result = await _appServiceHandler.ExcluirMovimentoFinanceiro(id);

            if (!result)
            {
                _uow.Rollback();
                return BadRequest(new { Message = $"Falha ao excluir o(s) movimento(s)." });
            }

            _uow.Commit();
            return Ok(result);
        }

        [HttpDelete]
        [Route("excluirMovimento/data")]
        [Authorize]
        public async Task<ActionResult<bool>> ExcluirMovimentoFinanceiro([FromQuery] DateTime data)
        {
            var result = await _appServiceHandler.ExcluirMovimentoFinanceiro(data).ConfigureAwait(false);

            if (!result)
            {
                _uow.Rollback();
                return BadRequest(new { Message = $"Falha ao excluir o movimento de {data}." });
            }

            _uow.Commit();
            return Ok(result);
        }
    }
}
