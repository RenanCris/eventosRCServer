using EventosRC.Dominio.Contratos;
using EventosRC.Entidades;
using EventosRC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventosRC.Controllers
{
    [RoutePrefix("evento")]
    public class EventoController : ApiController
    {
        private readonly IEventoService service;

        public EventoController(IEventoService service)
        {
            this.service = service;
        }

        [Route("v1/count")]
        [HttpGet]
        public IHttpActionResult GetTotal(EventoModel model) {
            return Ok(this.service.GetTotalEventos());
        }

        [Authorize(Roles ="Admin")]
        [Route("v1/create")]
        [HttpPost]
        public IHttpActionResult Criar(EventoModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Content(HttpStatusCode.Forbidden, ErrosModel());
                }

                var _obj = new Evento()
                {
                    Data = model.Data,
                    Descricao = model.Descricao,
                    Endereco = model.Endereco,
                    TipoEvento = model.TipoEvento,
                    Valor = model.Valor,
                    Cidade = model.Cidade
                };

                this.service.Add(_obj);

                return Ok("Evento Registrado!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("v1/get")]
        [HttpGet]
        public IHttpActionResult GetTodas()
        {
            try
            {
                var c1 = new List<object>();

                this.service.GetTodos().ForEach(c =>
                {
                    c1.Add(new
                    {
                        Data = c.Data,
                        Descricao = c.Descricao,
                        Endereco = c.Endereco,
                        TipoEvento = c.TipoEvento,
                        Valor = c.Valor,
                        Cidade = c.Cidade
                    });
                });
                return Ok(c1);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [NonAction]
        public List<string> ErrosModel()
        {

            var errorList = ModelState.Values.SelectMany(m => m.Errors)
                                     .Select(e => e.ErrorMessage)
                                     .ToList();
            return errorList;
        }
    }
}
