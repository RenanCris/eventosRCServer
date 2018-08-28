using EventosRC.Dominio.Contratos;
using EventosRC.Entidades;
using EventosRC.Helper;
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
    [Authorize]
    [RoutePrefix("compra")]
    public class CompraController : ApiController
    {
        private readonly ICompraService compraService;

        public CompraController(ICompraService compraService)
        {
            this.compraService = compraService;
        }

        [Route("v1/comprar")]
        [HttpPost]
        public IHttpActionResult Comprar(CompraCartaoModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Content(HttpStatusCode.Forbidden, ErrosModel());
                }

                var usuario = UsuarioHeleper.GetDadosUsuarioLogado(Request);

                List<Evento> eventos = new List<Evento>();

                model.Eventos.ToList().ForEach(x => {
                    eventos.Add(new Evento() {
                        Data = x.Data,
                        Cidade = x.Cidade,
                        Descricao = x.Descricao,
                        Endereco = x.Endereco,
                        TipoEvento = x.TipoEvento,
                        Valor = x.Valor
                    });
                });

                var compra = new Compra()
                {
                    Cpf = usuario.Cpf,
                    Eventos = eventos,
                    ValorTotal = model.ValorTotal,
                    Cartao = new Cartao() {
                        Numero = model.Numero,
                        Cvv = model.Cvv
                    }
                };

                try
                {
                    this.compraService.Add(compra);
                } catch (Exception e) {
                    return BadRequest(e.Message);
                }

                return Ok("Compra Registrada!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("v1/get")]
        [HttpGet]
        public IHttpActionResult GetSuasCompras()
        {
            try
            {
                var c1 = new List<object>();

                var usuario = UsuarioHeleper.GetDadosUsuarioLogado(Request);

                this.compraService.GetSuasCompras(usuario.Cpf).ToList().ForEach(c =>
                {
                    List<object> eventos = new List<object>();

                    c.Eventos.ToList().ForEach(x => {
                        eventos.Add(new { TipoEvento = x.TipoEvento, Descricao = x.Descricao });    
                    });

                    c1.Add(new
                    {
                        QtdEventos = c.Eventos.Count,
                        Eventos = eventos,
                        Valor = c.ValorTotal,
                        CartaoUsado = c.Cartao,
                        DataCompra = c.DataCompra
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
