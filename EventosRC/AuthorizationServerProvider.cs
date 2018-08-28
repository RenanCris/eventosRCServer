using EventosRC.Dominio.Contratos;
using EventosRC.Dominio.Implementacao;
using EventosRC.Entidades;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace EventosRC
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var header = context.OwinContext.Response.Headers.SingleOrDefault(h => h.Key == "Access-Control-Allow-Origin");
            if (header.Equals(default(KeyValuePair<string, string[]>)))
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            }

            try
            {
                var user = context.UserName;
                var password = context.Password;

                IPessoaService service = new PessoaService();

                Pessoa usuario = service.Autenticar(user, password);

                if (usuario == null)
                {
                    context.SetError("invalid_grant", "CPF ou senha inválidos");
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("Nome", usuario.Nome));
                identity.AddClaim(new Claim("Cpf", usuario.Cpf));

                var roles = new List<string>();

                if (usuario.Nome.Equals("Admin")){
                    roles.Add("Admin");
                }
                else
                    roles.Add("Cliente");

                var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    { "nome", usuario.Nome },
                    { "email", usuario.Email },
                    { "cpf", usuario.Cpf },
                    { "perfil", roles[0]}
                });

                foreach (var role in roles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));
                }

                GenericPrincipal principal = new GenericPrincipal(identity, roles.ToArray());
                Thread.CurrentPrincipal = principal;

                var ticket = new AuthenticationTicket(identity, props);
                context.Validated(ticket);
            }
            catch (Exception e)
            {
                context.SetError("invalid_grant", "Falha na autenticação");
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            return Task.FromResult<object>(null);
        }
    }
}