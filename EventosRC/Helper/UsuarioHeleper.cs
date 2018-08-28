using EventosRC.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web;

namespace EventosRC.Helper
{
    public class UsuarioHeleper
    {
        public static Pessoa GetDadosUsuarioLogado(HttpRequestMessage Request) {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var CPF = principal.Claims.Where(c => c.Type == "Cpf").Single().Value;

            return new Pessoa()
            {
                Cpf = CPF
            };
        }
    }
}