using System.Collections.Generic;
using System.Web.Http;

namespace WebApiTemplate.Controllers.v1
{
    /// <summary>
    /// Controlador de ejemplo que solicita autenticacion
    /// </summary>
    [Authorize]
    [RoutePrefix("api/autenticado")]
    public class AutenticadoController : ApiController
    {
        /// <summary>
        /// Obtiene una lista
        /// </summary>
        /// <returns>Lista de strings.</returns>
        /// <response code="200">Obtención de lista satisfactoria.</response>
        /// <response code="401">Request no autenticado.</response>
        [HttpGet, Route("")]
        //[Authorize(Roles = "admin")] // Puedo verificar roles o utilizar un custom authorization filter
        public IHttpActionResult Get()
        {
            var lista = new List<string>
            {
                "hola",
                "mundo"
            };

            return Ok(lista);
        }
    }
}
