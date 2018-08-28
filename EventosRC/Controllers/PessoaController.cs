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
    [RoutePrefix("pessoa")]
    public class PessoaController : ApiController
    {
        private readonly IPessoaService service;

        public PessoaController(IPessoaService service)
        {
            this.service = service;
        }

        [Route("v1/create")]
        [HttpPost]
        public IHttpActionResult Criar([FromBody] PessoaModel model)
        {
            try
            {
                if (!ModelState.IsValid){
                    return Content(HttpStatusCode.Forbidden, ErrosModel());
                }

                var pessoa = new Pessoa()
                {
                    Nome = model.Nome,
                    Cpf = model.Cpf,
                    DataNascimento = model.DataNascimento,
                    Email = model.Email,
                    Endereco = model.Endereco,
                    Sexo = model.Sexo,
                    Senha = model.Senha
                };
                if (!this.service.IsPessoaExistsByCpf(pessoa.Cpf))
                    this.service.Add(pessoa);
                else
                    return Content(HttpStatusCode.Forbidden, "CPF já Cadastrado");

                return Ok("Pessoa Registrada!");
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
                        Nome = c.Nome
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
