using System.Configuration;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Owin;

[assembly: OwinStartup(typeof(WebApiTemplate.Startup))]
namespace WebApiTemplate
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            //Configura OAuth para validar JWT
            ConfigureOAuth(app);

            //Configura CORS para habilitar todas las llamadas desde cualquier dominio, mas: http://benfoster.io/blog/aspnet-webapi-cors
            app.UseCors(CorsOptions.AllowAll);

            //Configuracion de Web Api
            WebApiConfig.Register(config);

            var httpServer = new HttpServer(config);
            app.UseWebApi(httpServer);
        }

        //configuración de OAuth para servidor de recursos, ver: http://bitoftech.net/2014/10/27/json-web-token-asp-net-web-api-2-jwt-owin-authorization-server/
        public void ConfigureOAuth(IAppBuilder app)
        {
            var issuer = ConfigurationManager.AppSettings["AuthenticationServerIssuerUrl"];
            var audiences = ConfigurationManager.AppSettings["ClientIdsAllowed"].Split(',');
            var secret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["Base64Secret"]);

            // Los controladores de la API con el attributo [Authorize] se validarán con el JWT, estas pocas lineas de código hacen la magia.
            // si se quiere agregar validación adicional se tendrá que crear un provider customizado o un token handler
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = audiences,
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret)
                    },
                    //Provider = new CustomOauthJwtAuthenticationProvider(); // para agregar autenticación adicional para autenticar o validar tokens usando un proveedor de autenticación costumizado ver: https://stackoverflow.com/questions/35586663/how-to-apply-custom-validation-to-jwt-token-on-each-request-for-asp-net-webapi
                });

        }
    }
}