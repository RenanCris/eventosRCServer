
using EventosRC.Dominio.Contratos;
using EventosRC.Infra.Data.Entidades;
using EventosRC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventosRC.Controllers
{
    [RoutePrefix("cidade")]
    public class CidadeController : ApiController
    {
        private readonly ICidadeService cidadeService;

        public CidadeController(ICidadeService cidadeService)
        {
            this.cidadeService = cidadeService;
        }

        [Authorize(Roles = "Admin")]
        [Route("v1/create")]
        [HttpPost]
        public IHttpActionResult CriarCidade(CidadeModel model) {
            try{
                var cidade = new Cidade()
                {
                    Descricao = model.Descricao
                };

                this.cidadeService.Add(cidade);

                return Ok("Cidade Criada!");
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [Route("v1/get")]
        [HttpGet]
        public IHttpActionResult GetTodasCidades()
        {
            try
            {
                var c1 = new List<object>();

                this.cidadeService.GetTodos().ForEach(c =>
                {
                    c1.Add(new
                    {
                        Descricao = c.Descricao,
                        Id = c.Id
                    });
                });
                return Ok(c1);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}
