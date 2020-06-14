using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioMobills.WebApi.Entidades;
using DesafioMobills.WebApi.Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioMobills.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        [HttpGet("acompanhamento/{idConta}")]
        [ProducesResponseType(typeof(Conta), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoApi), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RetornoApi), StatusCodes.Status404NotFound)]
        public IActionResult BuscarPorId(int idConta, [FromServices] ContaNegocio negocio)
        {
            try
            {
                var contaDb = negocio.ObterPorId(idConta);

                if (contaDb == null)
                {
                    return NotFound(new RetornoApi { MensagemRetorno = "Conta não encontrada." });
                }
                return Ok(contaDb);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}