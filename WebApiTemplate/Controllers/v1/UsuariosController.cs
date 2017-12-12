using System.Collections.Generic;
using System.Web.Http;
using Microsoft.Web.Http;

namespace WebApiTemplate.Controllers.v1
{
    /// <summary>
    /// 
    /// </summary>
    [ApiVersion("1.0", Deprecated = true)]
    [RoutePrefix("api/usuarios")]
    public class UsuariosController : ApiController
    {        
        /*
         * Mas informacion de ruting: https://docs.microsoft.com/en-us/aspnet/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2
         */

        /// <summary>
        /// Obtiene todos los usuarios
        /// </summary>
        /// <returns>Todos los usuarios disponibles.</returns>
        /// <response code="200">Obtención de usuarios satisfactoria.</response>
        [HttpGet, Route("")]
        public IHttpActionResult Get()
        {
            var listaUsuarios = new List<Usuario>
            {
                new Usuario()
                {
                    Id = 1,
                    Email = "alberto@microsoft.com",
                    Nombre = "Albergo Gaona"
                },
                new Usuario()
                {
                    Id = 2,
                    Email = "Iliana@microsoft.com",
                    Nombre = "Iliana Garduño"
                }
            };

            return Ok(listaUsuarios);
        }

        /// <summary>
        /// Elimina un usuario
        /// </summary>
        /// <param name="id">El identificador del usuario.</param>
        /// <returns>Id del usuario eliminado.</returns>
        /// <response code="200">Eliminación satisfactoria.</response>
        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            return Ok(id);
        }
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
    }
}
