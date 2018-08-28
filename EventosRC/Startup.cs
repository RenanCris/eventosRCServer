using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Owin;
using Swashbuckle.Application;
using System;
using System.Web.Http;
using Unity.AspNet.WebApi;

namespace EventosRC
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            config.DependencyResolver = new UnityDependencyResolver(
            EventosRC.UnityConfig.Container);    

            Register(config);
            ConfigureOauth(app);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public void ConfigureOauth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(10),
                Provider = new AuthorizationServerProvider()

            };

            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }

        public static void Register(HttpConfiguration config)
        {
            //var cors = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(cors);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
            name: "EventosRC",
            routeTemplate: "",
            defaults: null,
            constraints: null,
            handler: new RedirectHandler(SwaggerDocsConfig.DefaultRootUrlResolver, "swagger/ui/index"));

            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "EventosRC.API");
            })
            .EnableSwaggerUi(c =>
            {
            });

            config.Routes.MapHttpRoute(
                name: "apiEvetosRc",
                routeTemplate: "apiEvetosRc/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
        }

    }
}