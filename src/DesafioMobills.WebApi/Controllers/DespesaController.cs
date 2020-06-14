using DesafioMobills.WebApi.Entidades;
using DesafioMobills.WebApi.Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioMobills.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DespesaController : ControllerBase
    {
        [HttpPost("criar")]
        [ProducesResponseType(typeof(RetornoApi), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoApi), StatusCodes.Status400BadRequest)]
        public IActionResult Insert([FromBody] Despesa despesa, [FromServices] DespesaNegocio negocio, [FromServices] ContaNegocio contaNegocio)
        {
            try
            {
                var contaDb = contaNegocio.ObterPorId(despesa.Id_Conta);

                if (contaDb == null)
                {
                    return NotFound(new RetornoApi { MensagemRetorno = "Conta não encontrada." });
                }

                negocio.Salvar(despesa);
                return Ok(new RetornoApi { MensagemRetorno = "Despesa criada com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new RetornoApi { MensagemRetorno = ex.Message });
            }
        }

        [HttpPut("atualizar")]
        [ProducesResponseType(typeof(RetornoApi), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoApi), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RetornoApi), StatusCodes.Status404NotFound)]
        public IActionResult Atualizar([FromBody] Despesa despesa, [FromServices] DespesaNegocio negocio)
        {
            try
            {
                var despesaDb = negocio.ObterPorId(despesa.Id);

                if (despesaDb == null)
                {
                    return NotFound(new RetornoApi { MensagemRetorno = "Receita não encontrada." });
                }

                negocio.Salvar(despesa);
                return Ok(new RetornoApi { MensagemRetorno = "Despesa atualizada com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new RetornoApi { MensagemRetorno = ex.Message });
            }
        }

        [HttpDelete("excluir/{id}")]
        [ProducesResponseType(typeof(RetornoApi), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoApi), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RetornoApi), StatusCodes.Status404NotFound)]
        public IActionResult Remover(int id, [FromServices] DespesaNegocio repositorio)
        {
            try
            {
                var despesaDb = repositorio.ObterPorId(id);

                if (despesaDb == null)
                {
                    return NotFound(new RetornoApi { MensagemRetorno = "Despesa não encontrada." });
                }
                
                repositorio.Excluir(id);
                return Ok(new RetornoApi { MensagemRetorno = "Despesa excluída com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new RetornoApi { MensagemRetorno = ex.Message });
            }
        }

        [HttpGet("buscar/{id}")]
        [ProducesResponseType(typeof(Despesa), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoApi), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RetornoApi), StatusCodes.Status404NotFound)]
        public IActionResult BuscarPorId(int id, [FromServices] DespesaNegocio negocio)
        {
            try
            {
                var despesaDb = negocio.ObterPorId(id);

                if (despesaDb == null)
                {
                    return NotFound(new RetornoApi { MensagemRetorno = "Despesa não encontrada." });
                }
                return Ok(despesaDb);
            }
            catch (Exception ex)
            {
                return BadRequest(new RetornoApi { MensagemRetorno = ex.Message });
            }
        }

        [HttpGet("buscar")]
        [ProducesResponseType(typeof(IEnumerable<Despesa>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoApi), StatusCodes.Status400BadRequest)]
        public IActionResult Listar([FromServices] DespesaNegocio negocio)
        {
            try
            {
                return Ok(negocio.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(new RetornoApi { MensagemRetorno = ex.Message });
            }
        }
    }
}