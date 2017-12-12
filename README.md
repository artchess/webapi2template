

Como crear templates
https://blogs.msdn.microsoft.com/dotnet/2017/04/02/how-to-create-your-own-templates-for-dotnet-new/

OJO: necesitas tener instalado el SDK de visual studio 2017


Template Engine (repositorio)
https://github.com/dotnet/templating/

Template Engine (ejemplos)
https://github.com/dotnet/dotnet-template-samples

Template Engine (wiki)
https://github.com/dotnet/templating/wiki

Extensión SideWafflev2:
https://github.com/ligershark/sidewafflev2

Otro: 
https://docs.microsoft.com/en-us/visualstudio/extensibility/creating-custom-project-and-item-templates


Para Item Templates:

https://github.com/ligershark/side-waffle
https://www.youtube.com/watch?v=h4VaORKgrOw&feature=youtu.be


Básicas:
Swashbuckle -- Swagger
Newtonsoft.Json -- para parsear respuestas de las APIs a JSON 
Microsoft.AspNet.WebApi.Owin -- para hostear la web api en un servidor OWIN y proveer acceso adicional a características de OWIN
Microsoft.Owin.Host.SystemWeb -- para habilitar el servidor owin para correr la api en IIS usando el request pipeline de ASP.NET
Microsoft.Owin.Cors -- para aceptar requests de origenes de diferentes dominios.
Microsoft.Owin.Security.OAuth -- para utilizar el workflow de autenticación de OAuth
Microsoft.Owin.Security.Jwt -- middleware que habilita que la aplicación pueda protejer y validar JWT
System.IdentityModel.Tokens.Jwt (instalar versión 4.0 es la que se instala con la librería anterior https://github.com/aspnet/AspNetKatana/issues/76#event-1129377509) -- para entender, validar y deserealizar JWT 
Microsoft.AspNet.WebApi.Versioning -- Librería para manejar facilmente el versionado de api
Microsoft.AspNet.WebApi.Versioning.ApiExplorer -- Librería para integrar Api Versioning con Swagger

Recomendadas:
utilizar unity (librería Unity.WebAPI): para integrar el contenedor Unity para IoC
implementar Refresh token: http://bitoftech.net/2014/07/16/enable-oauth-refresh-tokens-angularjs-app-using-asp-net-web-api-2-owin/

Documentacion:
* Las librería para autenticación y autorización con OAuth2 Owin usando JWT se basa en las siguientes ligas:
http://bitoftech.net/2014/06/01/token-based-authentication-asp-net-web-api-2-owin-asp-net-identity/
http://bitoftech.net/2014/10/27/json-web-token-asp-net-web-api-2-jwt-owin-authorization-server/


<!--/-:cdn -->
