using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Web.Http;
using Microsoft.Web.Http.Versioning;
using Newtonsoft.Json.Serialization;
using Swashbuckle.Application;

namespace WebApiTemplate
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            ConfigureVersioning(config);

            ConfigureApiRoutesAndFormatters(config);

            ConfigureSwagger(config);
        }

        private static void ConfigureSwagger(HttpConfiguration config)
        {
            // https://github.com/Microsoft/aspnet-api-versioning/wiki/API-Documentation#aspnet-web-api
            // https://github.com/Microsoft/aspnet-api-versioning/tree/master/samples/webapi/SwaggerWebApiSample
            // add the versioned IApiExplorer and capture the strongly-typed implementation (e.g. VersionedApiExplorer vs IApiExplorer)
            // note: the specified format code will format the version as "'v'major[.minor][-status]"
            var apiExplorer = config.AddVersionedApiExplorer(o => o.GroupNameFormat = "'v'VVV");

            config.EnableSwagger(
                    "{apiVersion}/swagger",
                    swagger =>
                    {
                        // Configuración de Bearer Token por cabecera. Ojo: tambien se debe configurar 'EnableApiKeySupport' abajo en la seccion SwaggerUI
                        swagger.ApiKey("Token")
                            .Description("Bearer {token}")
                            .Name("Authotization")
                            .In("header");

                        // Construye un documento swagger y su endpoint para cada versión de API descubierta
                        swagger.MultipleApiVersions(
                            (apiDescription, version) => apiDescription.GetGroupName() == version,
                            info =>
                            {
                                foreach (var group in apiExplorer.ApiDescriptions)
                                {
                                    var description =
                                        "Api con Swagger, Swashbuckle, y API versioning.";

                                    if (@group.IsDeprecated)
                                    {
                                        description += " Esta versión de API ha sido deprecada.";
                                    }

                                    info.Version(@group.Name, $"Template API {@group.ApiVersion}")
                                        .Contact(c => c.Name("@Contacto").Email("contacto@somewhere.com"))
                                        .Description(description)
                                        .License(l => l.Name("MIT").Url("https://opensource.org/licenses/MIT"))
                                        .TermsOfService("Shareware");
                                }
                            });

                        // Se agrega un OperationFilter que setea valores default, corrige bugs que están dentro de la clase SwaggerDefaultValues.cs
                        swagger.OperationFilter<SwaggerDefaultValues>();

                        // Integrar comentarios vía Xml, estos comentarios se generan a partir de los comentarios de los controlladores
                        // al construir la aplicación se genera un archivo en bin\WebApiTemplate.xml
                        swagger.IncludeXmlComments(XmlCommentsFilePath);
                    })
                .EnableSwaggerUi(swagger =>
                {
                    swagger.EnableDiscoveryUrlSelector();
                    swagger.EnableApiKeySupport("Authorization", "header");
                });
        }

        private static void ConfigureApiRoutesAndFormatters(HttpConfiguration config)
        {
            // Formato para regresar JSON y no XML por default
            var appXmlType =
                config.Formatters.XmlFormatter.SupportedMediaTypes
                    .FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            //Registrar cammelCase en formateador de JSON Response
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static void ConfigureVersioning(HttpConfiguration config)
        {
            config.AddApiVersioning(o =>
            {
                //en la cabecera de la respuestas se reporta las versiones de la api disponibles
                o.ReportApiVersions = true;
                //version default de la api
                o.DefaultApiVersion = new ApiVersion(1, 0);
                //permite cualquier cliente usar la API sin especificar la versión, toma la 1.0 como default
                o.AssumeDefaultVersionWhenUnspecified = true;
                //se lee la versión desde la cabecera de la petición
                o.ApiVersionReader = new HeaderApiVersionReader(ConfigurationManager.AppSettings["VersionParamName"]);
            });
        }

        static string XmlCommentsFilePath
        {
            get
            {
                var basePath = System.AppDomain.CurrentDomain.RelativeSearchPath;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }
    }
}
