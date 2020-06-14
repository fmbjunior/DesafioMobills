using DesafioMobills.WebApi.Entidades;
using DesafioMobills.WebApi.Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DesafioMobills.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        [HttpPost("criar")]
        [ProducesResponseType(typeof(RetornoApi), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoApi), StatusCodes.Status400BadRequest)]
        public IActionResult Inserir([FromBody] Receita receita, [FromServices] ReceitaNegocio negocio, [FromServices] ContaNegocio contaNegocio)
        {
            try
            {
                var contaDb = contaNegocio.ObterPorId(receita.Id_Conta);

                if (contaDb == null)
                {
                    return NotFound(new RetornoApi { MensagemRetorno = "Conta não encontrada." });
                }
                negocio.Salvar(receita);
                return Ok(new RetornoApi { MensagemRetorno = "Receita criada com sucesso." });
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
        public IActionResult Atualizar([FromBody] Receita receita, [FromServices] ReceitaNegocio negocio)
        {
            try
            {
                var receitaDb = negocio.ObterPorId(receita.Id);

                if (receitaDb == null)
                {
                    return NotFound(new RetornoApi { MensagemRetorno = "Receita não encontrada." });
                }

                negocio.Salvar(receita);
                return Ok(new RetornoApi { MensagemRetorno = "Receita atualizada com sucesso." });
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
        public IActionResult Remover(int id, [FromServices] ReceitaNegocio negocio)
        {
            try
            {
                var ReceitaDb = negocio.ObterPorId(id);

                if (ReceitaDb == null)
                {
                    return NotFound(new RetornoApi { MensagemRetorno = "Receita não encontrada." });
                }

                negocio.Excluir(id);
                return Ok(new RetornoApi { MensagemRetorno = "Receita excluída com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new RetornoApi { MensagemRetorno = ex.Message });
            }
        }

        [HttpGet("buscar/{id}")]
        [ProducesResponseType(typeof(Receita), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoApi), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RetornoApi), StatusCodes.Status404NotFound)]
        public IActionResult BuscarPorId(int id, [FromServices] ReceitaNegocio negocio)
        {
            try
            {
                var ReceitaDb = negocio.ObterPorId(id);

                if (ReceitaDb == null)
                {
                    return NotFound(new RetornoApi { MensagemRetorno = "Receita não encontrada." });
                }
                return Ok(ReceitaDb);
            }
            catch (Exception ex)
            {
                return BadRequest(new RetornoApi { MensagemRetorno = ex.Message });
            }
        }

        [HttpGet("buscar")]
        [ProducesResponseType(typeof(IEnumerable<Receita>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoApi), StatusCodes.Status400BadRequest)]
        public IActionResult Listar([FromServices] ReceitaNegocio negocio)
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