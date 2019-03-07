using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Domains;

namespace Senai.Senatur.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PacotesController : ControllerBase
    {
        [HttpGet("Listar")]
        public IActionResult ListarPacotes()
        {
            try
            {
                using (SenaturContext ctx = new SenaturContext())
                    return Ok(ctx.Pacotes.ToList());
            }
            catch 
            {
                return BadRequest();
            }
        }

        [HttpPost("Cadastrar")]
        public IActionResult CadastrarPacote(Pacotes pacote)
        {
            try
            {
                using (SenaturContext ctx = new SenaturContext())
                {
                    ctx.Pacotes.Add(pacote);
                    ctx.SaveChanges();
                }

                    return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpPut("Atualizar")]
        public IActionResult AtualizarPacote(Pacotes pacote)
        {
            try
            {
                using (SenaturContext ctx = new SenaturContext())
                {
                    ctx.Pacotes.Update(pacote);
                    ctx.SaveChanges();
                }
                    return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }
    }
}