using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.Application.QueryStack.ViewModel;
using MinhasFinancas.Infra.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhasFinancas.Api.Controllers.Financas
{
    [Controller]
    [Route("financas")]
    public class MovimentoFinanceiroController : ControllerBase
    {
        private readonly IMinhasFinancasAppServiceHandler _appServiceHandler;
        private readonly IUnitOfWork _uow;

        public MovimentoFinanceiroController(IMinhasFinancasAppServiceHandler appServiceHandler, IUnitOfWork uow)
        {
            _appServiceHandler = appServiceHandler;
            _uow = uow;
        }

        [HttpGet]
        [Route("allReceitas")]
        [Authorize]
        public async Task<ActionResult<MovimentoFinanceiroViewModel>> AllReceitas([FromQuery] DateTime data)
        {
            try
            {
                var result = await _appServiceHandler.AllReceitas(data.Date).ConfigureAwait(false);

                if (result is null)
                {
                    return NotFound(new { Message = $"Receitas em {data} não encontrado." });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("allDespesas")]
        [Authorize]
        public async Task<ActionResult<MovimentoFinanceiroViewModel>> AllDespesas([FromQuery] DateTime data)
        {
            try
            {
                var result = await _appServiceHandler.AllDespesas(data.Date).ConfigureAwait(false);

                if (result is null)
                {
                    return NotFound(new { Message = $"Despesas em {data} não encontrado." });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("salvarMovimento")]
        [Authorize]
        public async Task<ActionResult<bool>> GravarMovimentoFinanceiro([FromBody] MovimentoFinanceiroViewModel dados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(dados);
            }

            try
            {
                var result = await _appServiceHandler.GravarMovimentoFinanceiro(dados).ConfigureAwait(false);

                if (!result)
                {
                    _uow.Rollback();
                    return BadRequest(new { Message = $"Falha ao gravar o movimento." });
                }

                _uow.Commit();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("atualizarMovimento")]
        [Authorize]
        public async Task<ActionResult<bool>> AtualizarMovimentoFinanceiro([FromBody] MovimentoFinanceiroViewModel dados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(dados);
            }

            var result = await _appServiceHandler.AtualizarMovimentoFinanceiro(dados).ConfigureAwait(false);

            if (!result)
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
            if (!ModelState.IsValid)
            {
                return BadRequest(id);
            }

            var result = await _appServiceHandler.ExcluirMovimentoFinanceiro(id).ConfigureAwait(false);

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
            if (!ModelState.IsValid)
            {
                return BadRequest(data);
            }

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
